import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rune } from '../models/rune.model';

@Injectable({
  providedIn: 'root'
})
export class RuneService {

  constructor(private client: HttpClient) { }

  getRunes() : Observable<Rune[]> {
    return this.client.post<Rune[]>("http://localhost:5000/api", "{}", {
      headers: { 
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetRunesQuery, DiabloII-Cookbook.Api',
        'Correlation-Id': '{6073C47F-CB0B-41B2-B8C8-925A283AC4BD}',
        'Content-Type': "application/json"
      }
    });
  }
}
