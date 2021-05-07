import { concatMap, finalize, switchMap, take } from 'rxjs/operators';
import { RuneWord } from './../../models/rune-word.model';
import { ItemType } from './../../models/item-type.model';
import { DiabloiiClassicFilterService } from './../../services/filter/diabloii-classic-filter.service';
import { CharacterService } from '../../services/character/diabloii-classis-character.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Character } from './../../models/character.model';
import { ViewEncapsulation } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Rune } from 'src/app/shared/models/rune.model';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { DiabloiiClassisRuneService } from '../../services/rune/diabloii-classis-rune.service';
import { DiabloiiClassicNewCharacterComponent } from '../diabloii-classic-new-character/diabloii-classic-new-character.component';
import { LoadingScreen } from 'src/app/shared/models/loading-screen.model';
import { animate, style, transition, trigger } from '@angular/animations';
import { concat, forkJoin, merge, Observable,  } from 'rxjs';
import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y';

@Component({
  selector: 'app-diabloii-classic',
  templateUrl: './diabloii-classic.component.html',
  styleUrls: ['./diabloii-classic.component.scss'],
  animations: [trigger('fadeOut', [
    transition(':leave', [
      animate('200ms', style({ opacity: 0 }))
    ])
  ])]
})
export class DiabloiiClassicComponent implements OnInit {

  public characterForm: FormGroup = new FormGroup({
    class: new FormControl(''),
    name: new FormControl(''),
    level: new FormControl(1),
    isExpansion: new FormControl(false),
    isLadder: new FormControl(false)
  })

  public images: Array<LoadingScreen> = [
    { name: "Andariel", message: "Die, maggot!" },
    { name: "Duriel", message: "Looking for Baal!?" },
    { name: "Mephisto", message: "Cursed am I to lead an army of the blind; they do not perceive that the angels are fleeing this realm, and the ones they find are merely trapped or lost! A great change is upon us; withdraw from the fields, my brothers... ... some battles can only won with words..." },
    { name: "Diablo", message: "Not even death can save you from me!" },
    { name: "Baal", message: "Enough of your idle speculation, Mephisto! I breached the fortress and saw it firsthand: the Worldstone is GONE! The angels I killed knew nothing about it. But since you are so perceptive, maybe you remember who else has been missing: Lilith - we must find her, rip her limb from limb, take the Worldstone BACK!" }
  ]

  public weapons: Array<ItemType> = [];
  public armors: Array<ItemType> = [];
  public filterForm: FormGroup = new FormGroup({});

  public runeWords: RuneWord[] = [];

  public runes: Array<Rune> = []

  public characters: Array<string> = [];

  public loading: boolean = false;

  index: number = 0;

  constructor(private runeService: DiabloiiClassisRuneService,
    private characterService: CharacterService,
    private confirmationService: ConfirmationService,
    private dialogService: MatDialog,
    private filterService: DiabloiiClassicFilterService) {
  }

  ngOnInit(): void {
    this.loading = true;

    forkJoin([ this.runeService.getRunes(), this.filterService.getItemTypes()])
      .pipe(concatMap((projects) => {
          projects[1].forEach(it => this.filterForm.addControl(it.id, new FormControl(false)));
          this.weapons = projects[1].filter(it => it.group === "Weapon");
          this.armors = projects[1].filter(it => it.group === "Armor");

          projects[0].forEach(rune => this.characterForm.addControl(rune.id, new FormControl(false)));
          this.runes = projects[0];

          return this.characterService.getCharacters();
      }))
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: characters => { 
          this.characters = characters;
          this.refresh(0);
        }
      });
  }

  public hideLoadingScreen() {
    console.log("Hide loading screen");
    this.loading = false;
  }

  next(): void {
    if (this.index < this.characters.length - 1) {
      this.refresh(++this.index);
    }
  }

  previous(): void {
    if (this.index > 0) {
      this.refresh(--this.index);
    }
  }

  add(): void {
    this.dialogService.open(DiabloiiClassicNewCharacterComponent)
      .afterClosed().subscribe({
        next: (character: Character) => {
          if (character !== undefined && character !== null) {
            this.characterService.save(character).subscribe({
              next: response => {
                this.characterService.getCharacters()
                  .subscribe(characters => {
                    this.characters = characters;
                    this.refresh(this.characters.length - 1);
                  });
              }
            });
          }
        }
      });
  }

  delete(): void {
    const name = this.characterForm.get('name')?.value;
    this.confirmationService.confirm(`Do you really want to delete ${name}?`)
      .subscribe(result => {
        if (result) {
          this.characterService.delete(this.characters[this.index]).subscribe({
            next: response => {
              this.characterService.getCharacters().subscribe({
                next: characters => {
                  this.characters = characters;
                  this.refresh(0);
                }
              })
            }
          })
          this.refresh(this.index === 0 ? 0 : this.index === this.characters.length ? --this.index : this.index);
        }
      })
  }

  save(character: Character): void {
    this.characterService.update(this.characters[this.index], this.characterForm.get('level')?.value, this.runes.filter(r => this.characterForm.get(r.id)?.value ?? false))
      .subscribe({
        next: () => { }
      });
  }

  refresh(index: number) {
    this.characterService.getCharacter(this.characters[index]).subscribe({
      next: character => {
        console.log(character);

        this.characterForm.get('class')?.setValue(character.class);
        this.characterForm.get('name')?.setValue(character.name);
        this.characterForm.get('level')?.setValue(character.level);
        this.characterForm.get('isExpansion')?.setValue(character.isExpansion);
        this.characterForm.get('isLadder')?.setValue(character.isLadder);

        this.runes.forEach(rune => this.characterForm.get(rune.id)?.setValue(!!character.runes.find(cr => rune.id === cr.id)));

        this.weapons.forEach(w => this.filterForm.get(w.id)?.setValue(!!character.filter.itemTypes.includes(w.id)))
        this.armors.forEach(a => this.filterForm.get(a.id)?.setValue(!!character.filter.itemTypes.includes(a.id)))

        this.index = index;
      }
    })
  }

  selectItemTypeFilter(itemTypes: ItemType[]) {
    var targetValue = itemTypes.every(it => !this.filterForm.get(it.id)?.value);
    itemTypes.forEach(it => this.filterForm.get(it.id)?.setValue(targetValue));
  }

  getAllRuneWords(): void {
    this.filterService.getRuneWords()
      .subscribe({
        next: runeWords => this.runeWords = runeWords
      })
  }

  public saveItemTypeFilter(itemTypeId: string){
    if (this.filterForm.get(itemTypeId)?.value) {
      this.filterService.addFilter(this.characters[this.index], itemTypeId).subscribe({
        next: () => {}
      });
    }
  }
}
