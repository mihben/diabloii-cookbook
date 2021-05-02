import { ViewEncapsulation } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Rune } from 'src/app/shared/models/rune.model';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { Character } from '../../models/character.model';
import { DiabloiiClassisRuneService } from '../../services/diabloii-classis-rune.service';
import { DiabloiiClassicNewCharacterComponent } from '../diabloii-classic-new-character/diabloii-classic-new-character.component';

@Component({
  selector: 'app-diabloii-classic',
  templateUrl: './diabloii-classic.component.html',
  styleUrls: ['./diabloii-classic.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DiabloiiClassicComponent implements OnInit {
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
  character: Character = this.characters[this.index];

  constructor(private runeService: DiabloiiClassisRuneService,
    private confirmationService: ConfirmationService,
    private dialogService: MatDialog) { 
  }

  ngOnInit(): void {
    this.runeService.getRunes()
      .subscribe(runes => this.runes = runes);
  }

  next(): void {
    if (this.index < this.characters.length - 1) 
    {
      this.index = this.index + 1;
      this.character = this.characters[this.index];
    }
  }  
  
  previous(): void {
    if (this.index > 0) 
    {
      this.index = this.index - 1;
      this.character = this.characters[this.index];
    }
  }

  add() : void {
    this.dialogService.open(DiabloiiClassicNewCharacterComponent);
  }

  delete(): void {
    this.confirmationService.confirm(`Do you really want to delete ${this.character.name}?`)
      .subscribe(result => {
        if (result) {
          this.characters = this.characters.filter(c => c.name !== this.character.name);
          this.character = this.characters[this.index === 0 ? 0 : this.index === this.characters.length ? --this.index : this.index];
        }
      })
  }
}
