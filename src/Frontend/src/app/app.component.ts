import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';
import { Rune } from 'src/shared/models/rune.model';
import { RuneService } from 'src/shared/services/rune.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'diabloii-cookbook';
  runes : Rune[] = [];

  constructor(private runeService: RuneService) { }

  ngOnInit(): void {
    this.runeService.getRunes()
      .subscribe((runes) => {
        this.runes = runes;
      });
  }
}
