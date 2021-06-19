import { Component, Input, OnInit } from '@angular/core';
import { LoadingScreen } from '../../models/loading-screen.model';

@Component({
  selector: 'app-loading-screen',
  templateUrl: './loading-screen.component.html',
  styleUrls: ['./loading-screen.component.scss']
})
export class LoadingScreenComponent implements OnInit {
  @Input() assets: string = '';
  @Input() images: Array<LoadingScreen> = [];

  image: LoadingScreen = { name: '', message: '' };

  constructor() { }

  ngOnInit(): void {
    this.image = this.images[this.getRandomInt(0, this.images.length - 1)];
  }

  getRandomInt(min: number, max: number) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min);
  }
  
}
