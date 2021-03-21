import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Character } from '../models/character.model';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private client: HttpClient) { }

  getCharacters(): Observable<string[]> {
    return this.client.post<string[]>("http://localhost:5000/api", {}, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetCharactersQuery, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }

  getCharacterDetail(id: string) : Observable<Character> {
    return this.client.post<Character>("http://localhost:5000/api", { "Id": id }, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetCharacterDetailQuery, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }

  getClasses() : Observable<string[]> {
    return this.client.post<string[]>("http://localhost:5000/api", {}, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetClassesQuery, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }

  createCharacter(character: Character) {
    return this.client.post<string[]>("http://localhost:5000/api", character, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Commands.CreateCharacterCommand, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }
}
