import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rune } from 'src/app/shared/models/rune.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DiabloiiClassisRuneService {
  constructor(private client: HttpClient) { }

  getRunes() : Observable<Array<Rune>> {
    return this.client.post<Array<Rune>>(environment.backend.url, {}, { headers: new HttpHeaders({
      'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetRunesQuery, DiabloII-Cookbook.Api'
    }) });
  }
}
