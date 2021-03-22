import { Component, HostListener, OnInit, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Character } from 'src/shared/models/character.model';
import { Rune } from 'src/shared/models/rune.model';
import { CharacterService } from 'src/shared/services/character.service';
import { RuneService } from 'src/shared/services/rune.service';
import { CreateCharacterComponent } from './components/create-character/create-character.component';
import { DeleteConfirmationDialogComponent } from './components/delete-confirmation-dialog/delete-confirmation-dialog.component';
import { of, Subscription } from 'rxjs';
import { debounceTime, switchMap } from 'rxjs/operators';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { BrowserStack } from 'protractor/built/driverProviders';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'diabloii-cookbook';
  runes: Rune[] = [];
  characters: string[] = [];
  character: Character | any;
  classImage: string | undefined;

  characterForm: FormGroup;

  save: Subscription | undefined;

  constructor(private runeService: RuneService, private characterService: CharacterService, public dialog: MatDialog, private formBuidler: FormBuilder) {
    this.characterForm = this.formBuidler.group({
      level: []
    });
  }

  ngOnInit(): void {
    this.save?.unsubscribe();

    this.runeService.getRunes()
      .subscribe((runes) => {
        runes.forEach(rune => {
          this.characterForm.addControl(rune.id, new FormControl(false));
        });

        this.runes = runes;

        this.refreshCharacters();

        this.save = this.characterForm?.valueChanges
        .pipe(debounceTime(1500), switchMap((value) => of(value)))
        .subscribe(value => {
          console.log('Update character');
          var selectedRunes: Rune[] = [];
          this.runes.forEach(rune => {
            if (this.characterForm.get(rune.id)?.value) {
              selectedRunes.push(rune);
            }
          });
          this.characterService.updateCharacter(this.character?.id, value.level, selectedRunes)
            .subscribe();
        });
      });
  }

  private setCharacter(character: Character) {
    console.log("Set character");

    this.character = character;
    this.classImage = `../assets/classes/${this.character.class}.gif`;

    this.characterForm.controls['level'].setValue(character.level, {onlySelf: true, emitEvent: false})
    this.runes.forEach(rune => {
      this.characterForm.controls[rune.id].setValue(character.runes.some(cr => cr.id === rune.id), {onlySelf: true, emitEvent: false});
    });
  }

  @HostListener('wheel', ['$event'])
  onMousewheel(event: WheelEvent) {
    if (event.deltaX < 0)
      this.previous();
    else if (event.deltaX > 0)
      this.next();
  }

  @HostListener('window:keydown', ['$event'])
  onKeyDown(event: KeyboardEvent) {
    if (event.key === 'ArrowLeft')
      this.previous();
    else if (event.key === 'ArrowRight')
      this.next();
  }

  previous(): void {
    var index = this.characters?.indexOf(this.character.id);
    if (--index >= 0) {
      this.characterService.getCharacterDetail(this.characters[index])
        .subscribe((character) => {
          this.setCharacter(character);
        });
    }
  }

  next(): void {
    var index = this.characters.indexOf(this.character.id);
    if (++index < this.characters.length) {
      this.characterService.getCharacterDetail(this.characters[index])
        .subscribe((character) => {
          this.setCharacter(character);
        });
    }
  }

  addCharacter(): void {
    this.dialog.open(CreateCharacterComponent, { panelClass: 'mat-dialog' })
      .afterClosed()
      .subscribe(created => {
        if (created) {
          console.log('Created');

          this.refreshCharacters();
        }
      })
  }

  deleteCharacter(): void {
    this.dialog.open(DeleteConfirmationDialogComponent, { panelClass: 'mat-dialog' })
      .afterClosed()
      .subscribe(result => {
        if (result) {
          this.characterService.deleteCharacter(this.character?.id)
            .subscribe(() => this.refreshCharacters());
        } else { }
      });

  }

  private refreshCharacters(): void {
    this.character = null;
    this.characterService.getCharacters()
      .subscribe((characters) => {
        this.characters = characters;
        this.characterService.getCharacterDetail(this.characters[0])
          .subscribe((character) => {
            this.setCharacter(character);
          })
      });
  }
}