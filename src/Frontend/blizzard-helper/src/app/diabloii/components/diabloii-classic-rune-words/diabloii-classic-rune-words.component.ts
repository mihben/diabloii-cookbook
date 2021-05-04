import { RuneWord } from './../../models/rune-word.model';
import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-diabloii-classic-rune-words',
  templateUrl: './diabloii-classic-rune-words.component.html',
  styleUrls: ['./diabloii-classic-rune-words.component.scss'],
  encapsulation: ViewEncapsulation.Emulated
})
export class DiabloiiClassicRuneWordsComponent implements OnInit {
  @Input() runeWord: RuneWord = new RuneWord('', '', 0, false, [], [], []);
  @Input() level: number = 1;

  constructor() { }

  ngOnInit(): void {
  }

  public isAdoptable() : string {
    if (this.runeWord != undefined && this.level >= this.runeWord?.level) return "adoptable";
    else return "unadoptable"
  }

}
