import { ItemType } from './../../models/item-type.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RuneWord } from '../../models/rune-word.model';

@Injectable({
  providedIn: 'root'
})
export class DiabloiiClassicFilterService {

  constructor(private httpClient: HttpClient) { }

  public getItemTypes(): Observable<Array<ItemType>> {
    return this.httpClient.post<Array<ItemType>>(environment.backend.url, { }, { headers: new HttpHeaders({
      'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetItemTypesQuery, DiabloII-Cookbook.Api'
    }) });
  }

  public getRuneWords() {
    return this.httpClient.post<Array<RuneWord>>(environment.backend.url, { }, {headers: new HttpHeaders({
      'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetAllRuneWordsQuery, DiabloII-Cookbook.Api'
    }) })
  }
}
