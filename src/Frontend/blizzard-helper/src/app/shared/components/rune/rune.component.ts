import { Component, Input, OnInit } from '@angular/core';
import { Rune } from '../../models/rune.model';

@Component({
  selector: 'app-rune',
  templateUrl: './rune.component.html',
  styleUrls: ['./rune.component.scss']
})

export class RuneComponent implements OnInit {
  @Input() assets: string = '';
  @Input() rune: Rune = { id: '', name: '', level: 0, inArmor: '', inHelm: '', inShield: '', inWeapon: '' };
  @Input() level: number = 1;

  constructor() { }

  ngOnInit(): void {
  }

  public isAdoptable() : string {
    if (this.rune != undefined && this.level >= this.rune.level) return "adoptable";
    else return "unadoptable"
  }

  public isAdoptableName() : string {
    if (this.rune != undefined && this.level >= this.rune.level) return "name";
    else return "name-unadoptable"
  }
}
