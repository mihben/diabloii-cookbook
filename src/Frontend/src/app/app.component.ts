import { Component, HostListener, OnInit, SimpleChanges } from '@angular/core';
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

  @HostListener('wheel', ['$event']) 
  onMousewheel(event: WheelEvent) {
    console.log(event);
    

    if (event.deltaX < 0)
      this.previous();
    else if (event.deltaX > 0)
      this.next();
  }

  @HostListener('window:keydown', ['$event'])
  onKeyDown(event: KeyboardEvent)
  {
    if (event.key === 'ArrowLeft')
      this.previous();
    else if (event.key === 'ArrowRight')
      this.next();
  }

  previous() : void {
    var index = this.characters.indexOf(this.character.id);
    if (--index >= 0)
    {
      this.characterService.getCharacterDetail(this.characters[index])
      .subscribe((character) => {
        this.setCharacter(character);
      });
    }
  }
  
  next() : void {
    var index = this.characters.indexOf(this.character.id);
    if (++index < this.characters.length)
    {
      this.characterService.getCharacterDetail(this.characters[index])
      .subscribe((character) => {
        this.setCharacter(character);
      });
    }
  }
}
