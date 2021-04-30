import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rune } from 'src/app/shared/models/rune.model';

@Injectable({
  providedIn: 'root'
})
export class DiabloiiClassisRuneService {
  private url = 'http://localhost:5000/api';

  constructor(private client: HttpClient) { }

  getRunes() : Observable<Array<Rune>> {
    return this.client.post<Array<Rune>>(this.url, {}, { headers: new HttpHeaders({
      'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetRunesQuery, DiabloII-Cookbook.Api'
    }) });
  }
}
