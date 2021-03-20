import { Component, OnInit, SimpleChanges } from '@angular/core';
import { Character } from 'src/shared/models/character.model';
import { Rune } from 'src/shared/models/rune.model';
import { CharacterService } from 'src/shared/services/character.service';
import { RuneService } from 'src/shared/services/rune.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'diabloii-cookbook';
  runes : Rune[] = [];
  characters: string[] = [];
  character: Character | any;
  classImage: string | undefined;

  constructor(private runeService: RuneService, private characterService: CharacterService) { }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    
    this.classImage = `../app/assets/${changes.character.currentValue._class}.gif`;
  }

  ngOnInit(): void {
    this.runeService.getRunes()
      .subscribe((runes) => {
        this.runes = runes;
      });

    this.characterService.getCharacters()
      .subscribe((characters) => {
        this.characters = characters;
        this.characterService.getCharacterDetail(this.characters[0])
          .subscribe((character) => {
            this.setCharacter(character);
          })
      });
  }

  private setCharacter(character: Character) {
    this.character = character;
    this.classImage = `../assets/classes/${this.character.class}.gif`;
  }
}
