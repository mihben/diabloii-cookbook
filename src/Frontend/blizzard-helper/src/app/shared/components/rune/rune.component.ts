import { Component, Input, OnInit } from '@angular/core';
import { Rune } from '../../models/rune.model';

@Component({
  selector: 'app-rune',
  templateUrl: './rune.component.html',
  styleUrls: ['./rune.component.scss']
})

export class RuneComponent implements OnInit {
  @Input() assets: string = '';
  @Input() rune: Rune = { id: '', name: '' };
  
  constructor() { }

  ngOnInit(): void {
  }

}
