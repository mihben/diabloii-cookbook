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
import { ItemType } from 'src/shared/models/itemType.model';
import { FilterService } from 'src/shared/services/filter.service';
import { RuneWord } from 'src/shared/models/runeWord.model';

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
  characterIndex: number = 0;
  classImage: string | undefined;

  armors: ItemType[] = [];
  weapons: ItemType[] = [];

  characterForm: FormGroup;
  filterForm: FormGroup;

  save: Subscription | undefined;

  runeWords: RuneWord[] | undefined;

  constructor(private runeService: RuneService, private characterService: CharacterService, public dialog: MatDialog, private formBuidler: FormBuilder, private filterService: FilterService) {
    this.characterForm = this.formBuidler.group({
      level: [],
      isLadder: [],
      isExpansion: []
    });

    this.filterForm = this.formBuidler.group({
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
            var selectedRunes: Rune[] = [];
            this.runes.forEach(rune => {
              if (this.characterForm.get(rune.id)?.value) {
                selectedRunes.push(rune);
              }
            });
            this.characterService.updateCharacter(this.character?.id, value.level, value.isLadder, value.isExpansion, selectedRunes)
              .subscribe();
          });
      });
          
      this.filterService.getItemTypes()
      .subscribe((itemTypes) => {
        itemTypes.forEach(itemType => {
          this.filterForm.addControl(itemType.id, new FormControl(false));
        });

        this.armors = itemTypes.filter(it => it.group === 'Armor');
        this.weapons = itemTypes.filter(it => it.group === 'Weapon');
      });
  }

  setCharacter(character: Character) {
    this.character = character;
    this.characterIndex = this.characters.indexOf(this.character.id) + 1;

    this.classImage = `../assets/classes/${this.character.class}.gif`;

    this.characterForm.controls['level'].setValue(character.level, { onlySelf: true, emitEvent: false })
    this.characterForm.controls['isLadder'].setValue(character.isLadder, { onlySelf: true, emitEvent: false })
    this.characterForm.controls['isExpansion'].setValue(character.isExpansion, { onlySelf: true, emitEvent: false })
    this.runes.forEach(rune => {
      this.characterForm.controls[rune.id].setValue(character.runes.some(cr => cr.id === rune.id), { onlySelf: true, emitEvent: false });
    });
  }

  previous(): void {
    var index = this.characters?.indexOf(this.character.id);
    if (--index >= 0) {
      this.characterService.getCharacterDetail(this.characters[index])
        .subscribe((character) => {
          this.setCharacter(character);
          this.characterIndex = index + 1;
        });
    }
  }

  next(): void {
    var index = this.characters.indexOf(this.character.id);
    if (++index < this.characters.length) {
      this.characterService.getCharacterDetail(this.characters[index])
        .subscribe((character) => {
          this.setCharacter(character);
          this.characterIndex = index + 1;
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

  public getAllRuneWords(): void {
    this.runeWords = undefined;
    this.filterService.getAllRuneWords()
      .subscribe(runeWords => {
        this.runeWords = runeWords
      });
  }

  public getRuneWords(): void {
    this.runeWords = undefined;
    var itemTypes: ItemType[] = [];
    var runes: Rune[] = [];

    this.armors.forEach(armor => {
      if (this.filterForm.get(armor.id)?.value) itemTypes.push(armor);
    })
    this.weapons.forEach(weapon => {
      if (this.filterForm.get(weapon.id)?.value) itemTypes.push(weapon);
    })

    this.runes.forEach(rune => {
      if (this.characterForm.get(rune.id)?.value) runes.push(rune);
    })

    this.filterService.getRuneWords(itemTypes, runes)
      .subscribe(runeWords => {
        this.runeWords = runeWords
      });
  }
}
