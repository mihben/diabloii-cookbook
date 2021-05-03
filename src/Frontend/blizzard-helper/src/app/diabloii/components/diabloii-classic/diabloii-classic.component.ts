import { CharacterService } from './../../services/character.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Character } from './../../models/character.model';
import { ViewEncapsulation } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Rune } from 'src/app/shared/models/rune.model';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { DiabloiiClassisRuneService } from '../../services/diabloii-classis-rune.service';
import { DiabloiiClassicNewCharacterComponent } from '../diabloii-classic-new-character/diabloii-classic-new-character.component';

@Component({
  selector: 'app-diabloii-classic',
  templateUrl: './diabloii-classic.component.html',
  styleUrls: ['./diabloii-classic.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DiabloiiClassicComponent implements OnInit {

  public characterForm: FormGroup = new FormGroup({
    class: new FormControl(''),
    name: new FormControl(''),
    level: new FormControl(1),
    isExpansion: new FormControl(false),
    isLadder: new FormControl(false)
  })

  runeWords: Array<string> = [
    "Nadir",
    "Nadir",
    "Nadir",
    "Nadir",
    "Nadir"
  ]

  runes: Array<Rune> = [ ]

  characters: Array<string> = [];

  index: number = 0;

  constructor(private runeService: DiabloiiClassisRuneService,
    private characterService: CharacterService,
    private confirmationService: ConfirmationService,
    private dialogService: MatDialog) { 
  }

  ngOnInit(): void {
    this.runeService.getRunes()
      .subscribe(runes => 
        {
          runes.forEach(rune => this.characterForm.addControl(rune.id, new FormControl(false)));
          this.runes = runes

          this.characterService.getCharacters()
          .subscribe(characters => {          
            this.characters = characters;
            this.refresh(0);
          });
        });
  }

  next(): void {
    if (this.index < this.characters.length - 1) 
    {
      this.refresh(++this.index);
    }
  }  
  
  previous(): void {
    if (this.index > 0) 
    {
      this.refresh(--this.index);
    }
  }

  add() : void {
    this.dialogService.open(DiabloiiClassicNewCharacterComponent)
      .afterClosed().subscribe({
        next: (character: Character) => {
          if (character !== undefined && character !== null){
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
        console.log(character.class);
        
        this.characterForm.get('class')?.setValue(character.class);    
        this.characterForm.get('name')?.setValue(character.name);    
        this.characterForm.get('level')?.setValue(character.level);    
        this.characterForm.get('isExpansion')?.setValue(character.isExpansion);    
        this.characterForm.get('isLadder')?.setValue(character.isLadder);   
        
        this.runes.forEach(rune => this.characterForm.get(rune.id)?.setValue(!!character.runes.find(cr => rune.id === cr.id)));
        
        this.index = index;
      }
    })
  }
}
