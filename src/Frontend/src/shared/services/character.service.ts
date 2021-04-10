import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { Character } from '../models/character.model';
import { Rune } from '../models/rune.model';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private client: HttpClient, private authService: OAuthService) { }

  getCharacters(): Observable<string[]> {
    return this.client.post<string[]>("http://localhost:5000/api", {}, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetCharactersQuery, DiabloII-Cookbook.Api',
        'Content-Type': "application/json"
      }
    });
  }

  getCharacterDetail(id: string) : Observable<Character> {
    return this.client.post<Character>("http://localhost:5000/api", { "Id": id }, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetCharacterDetailQuery, DiabloII-Cookbook.Api',
        'Content-Type': "application/json"
      }
    });
  }

  getClasses() : Observable<string[]> {
    return this.client.post<string[]>("http://localhost:5000/api", {}, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetClassesQuery, DiabloII-Cookbook.Api',
        'Content-Type': "application/json"
      }
    });
  }

  createCharacter(character: Character) {
    return this.client.post("http://localhost:5000/api", character, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Commands.CreateCharacterCommand, DiabloII-Cookbook.Api',
        'Content-Type': "application/json"
      }
    });
  }

  deleteCharacter(id: string| undefined) {
    return this.client.post("http://localhost:5000/api", { id: id }, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Commands.DeleteCharacterCommand, DiabloII-Cookbook.Api',
        'Content-Type': "application/json"
      }
    });
  }

    updateCharacter(id: string | undefined, level: number, isLadder: boolean, isExpansion: boolean, runes: Rune[]) {
      return this.client.post("http://localhost:5000/api", { id: id, level: level, isLadder: isLadder, isExpansion: isExpansion, runes: runes }, {
        headers: {
          'Message-Type': 'DiabloII_Cookbook.Api.Commands.UpdateCharacterCommand, DiabloII-Cookbook.Api',
          'Content-Type': "application/json"
        }
      });
    }
}
