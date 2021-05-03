import { CharacterService } from './../../services/character.service';
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

  public classes: Array<string> = [];

  formGroup = new FormGroup({
    name: new FormControl(''),
    class: new FormControl('Amazon'),
    level: new FormControl(1),
    isExpansion: new FormControl(true),
    isLadder: new FormControl(true),
  })

  constructor(private dialog: MatDialogRef<DiabloiiClassicNewCharacterComponent>,
    private characterService: CharacterService) { }

  ngOnInit(): void {
    this.characterService.getClasses()
      .subscribe({
        next: classes => this.classes = classes
      });
  }

  public save(character: Character) {
    this.dialog.close(character);
  }

  public cancel() {
    this.dialog.close();
  }
}
