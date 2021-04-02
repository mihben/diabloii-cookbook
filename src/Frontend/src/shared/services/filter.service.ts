import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ItemType } from '../models/itemType.model';
import { Rune } from '../models/rune.model';
import { RuneWord } from '../models/runeWord.model';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor(private client: HttpClient) { }

  getItemTypes(): Observable<ItemType[]> {
    return this.client.post<ItemType[]>("http://localhost:5000/api", { }, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetItemTypesQuery, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }

  getAllRuneWords(): Observable<RuneWord[]> {
    return this.client.post<RuneWord[]>("http://localhost:5000/api", { }, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetAllRuneWordsQuery, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }

  getRuneWords(itemTypes: ItemType[], runes: Rune[]): Observable<RuneWord[]> {
    return this.client.post<RuneWord[]>("http://localhost:5000/api", { itemTypes: itemTypes, runes: runes }, {
      headers: {
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetRuneWordsQuery, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }
}
