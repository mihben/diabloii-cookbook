import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Rune } from 'src/shared/models/rune.model';

@Component({
  selector: 'app-rune',
  templateUrl: './rune.component.html',
  styleUrls: ['./rune.component.scss']
})
export class RuneComponent implements OnInit, OnChanges {
  @Input() rune: Rune | undefined;
  imageSource: string | undefined;

  constructor() { }
  ngOnChanges(changes: SimpleChanges): void {
    this.imageSource = `../../../assets/runes/${this.rune?.name}.png`;
  }

  ngOnInit(): void {
  }

}
