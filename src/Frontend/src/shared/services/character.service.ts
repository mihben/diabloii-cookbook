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
    return this.client.get<string[]>("http://localhost:5000/api/Character", {});
  }

  getCharacterDetail(id: string) : Observable<Character> {
    return this.client.get<Character>(`http://localhost:5000/api/Character/${id}`);
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
    return this.client.post("http://localhost:5000/api/Character", character);
  }

  deleteCharacter(id: string| undefined) {
    return this.client.delete(`http://localhost:5000/api/Character/${id}`);
  }

    updateCharacter(id: string | undefined, level: number, isLadder: boolean, isExpansion: boolean, runes: Rune[]) {
      return this.client.put("http://localhost:5000/api/Character", { id: id, level: level, isLadder: isLadder, isExpansion: isExpansion, runes: runes });
    }
}
