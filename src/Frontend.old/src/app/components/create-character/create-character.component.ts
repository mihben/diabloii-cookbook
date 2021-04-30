import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Character } from 'src/shared/models/character.model';
import { CharacterService } from 'src/shared/services/character.service';

@Component({
  selector: 'app-create-character',
  templateUrl: './create-character.component.html',
  styleUrls: ['./create-character.component.scss']
})
export class CreateCharacterComponent implements OnInit {
  classes: string[] = [];
  
  class: string = "";
  name: string = "";
  level: number = 1;
  isLadder: boolean = false;
  isExpansion: boolean = true;

  constructor(public dialogRef: MatDialogRef<CreateCharacterComponent>, private characterService: CharacterService) { }

  ngOnInit(): void {
    this.characterService.getClasses()
      .subscribe(classes => {
        this.classes = classes;
        this.class = this.classes[0];
      })
  }

  create(): void {
    this.characterService.createCharacter(new Character("", this.class, this.name, this.level, this.isLadder, this.isExpansion, []))
      .subscribe(() => this.dialogRef.close(true));    
  }

  cancel(): void {
    this.dialogRef.close(false);
  }
}
