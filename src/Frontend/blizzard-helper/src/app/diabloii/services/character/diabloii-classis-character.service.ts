import { Rune } from '../../../shared/models/rune.model';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Character } from '../../models/character.model';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private httpClient: HttpClient) { }

  public getCharacters() : Observable<Array<string>> {
    return this.httpClient.get<Array<string>>(`${environment.backend.url}/character`);
  }

  public getCharacter(id: string) : Observable<Character> {    
    return this.httpClient.get<Character>(`${environment.backend.url}/character/${id}`);
  }

  public save(character: Character) : Observable<object> {
    return this.httpClient.post(`${environment.backend.url}/character`, character);
  }

  public getClasses() : Observable<Array<string>> {
    return this.httpClient.post<Array<string>>(`${environment.backend.url}`, {}, {
      headers: new HttpHeaders({
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetClassesQuery, DiabloII-Cookbook.Api'
      })
    });
  }

  public delete(id: string) : Observable<object> {
    return this.httpClient.delete(`${environment.backend.url}/character/${id}`);
  }

  public update(id: string, level: number, runes: Array<Rune>) : Observable<object> {
    return this.httpClient.put(`${environment.backend.url}/character/${id}`, { level, runes });
  }
}
