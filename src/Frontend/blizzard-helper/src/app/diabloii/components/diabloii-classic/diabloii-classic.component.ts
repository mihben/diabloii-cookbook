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
    $class: new FormControl(''),
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

  characters: Array<Character> = [
    new Character("Amazon", "Amazon", 10, true, false),
    new Character("Assassin", "Assassin", 8, true, true),
    new Character("Barbarian", "Barbarian", 20, true, false),
    new Character("Druid", "Druid", 75, false, false),
    new Character("Necromancer", "Necromancer", 20, true, false),
    new Character("Paladin", "Paladin", 39, true, true),
    new Character("Sorceress", "Sorceress", 65, true, false)
  ]

  index: number = 0;

  constructor(private runeService: DiabloiiClassisRuneService,
    private confirmationService: ConfirmationService,
    private dialogService: MatDialog) { 
  }

  ngOnInit(): void {
    this.runeService.getRunes()
      .subscribe(runes => 
        {
          runes.forEach(rune => this.characterForm.addControl(rune.id, new FormControl(false)));
          this.runes = runes
        });

    this.refresh(0);
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
            this.index = this.characters.push(character) - 1;
            this.refresh(this.index);
          }
        }
      });
  }

  delete(): void {
    const name = this.characterForm.get('name')?.value;
    this.confirmationService.confirm(`Do you really want to delete ${name}?`)
      .subscribe(result => {
        if (result) {   
          this.characters = this.characters.filter(c => c.name !== name);
          this.refresh(this.index === 0 ? 0 : this.index === this.characters.length ? --this.index : this.index);
        }
      })
  }

  save(character: Character): void {
    console.log(character);
  }

  refresh(index: number) {
    this.characterForm.get('$class')?.setValue(this.characters[index].$class);    
    this.characterForm.get('name')?.setValue(this.characters[index].name);    
    this.characterForm.get('level')?.setValue(this.characters[index].level);    
    this.characterForm.get('isExpansion')?.setValue(this.characters[index].isExpansion);    
    this.characterForm.get('isLadder')?.setValue(this.characters[index].isLadder);    
  }
}
