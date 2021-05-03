import { Character } from './../../models/character.model';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-diabloii-classic-new-character',
  templateUrl: './diabloii-classic-new-character.component.html',
  styleUrls: ['./diabloii-classic-new-character.component.scss']
})
export class DiabloiiClassicNewCharacterComponent implements OnInit {

  classes: Array<string> = [
    "Amazon",
    "Assassin",
    "Barbarian",
    "Druid",
    "Necromancer",
    "Paladin",
    "Sorcerress"
  ]

  formGroup = new FormGroup({
    "name": new FormControl(''),
    "$class": new FormControl('Amazon'),
    "level": new FormControl(1),
    "isExpansion": new FormControl(true),
    "isLadder": new FormControl(true),
  })

  constructor(private dialog: MatDialogRef<DiabloiiClassicNewCharacterComponent>) { }

  ngOnInit(): void {
  }

  public save(character: Character) {
    this.dialog.close(character);
  }

  public cancel() {
    this.dialog.close();
  }
}
