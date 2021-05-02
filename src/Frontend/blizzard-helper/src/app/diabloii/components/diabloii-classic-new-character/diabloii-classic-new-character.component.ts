import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-diabloii-classic-new-character',
  templateUrl: './diabloii-classic-new-character.component.html',
  styleUrls: ['./diabloii-classic-new-character.component.scss']
})
export class DiabloiiClassicNewCharacterComponent implements OnInit {

  formGroup = new FormGroup({
    "name": new FormControl(''),
    "class": new FormControl('Amazon'),
    "level": new FormControl(1),
    "isExpansion": new FormControl(true),
    "isLadder": new FormControl(true),
  })

  constructor() { }

  ngOnInit(): void {
  }

}
