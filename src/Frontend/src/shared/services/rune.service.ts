import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { Rune } from '../models/rune.model';

@Injectable({
  providedIn: 'root'
})
export class RuneService {

  constructor(private client: HttpClient, private authService: OAuthService) { }

  getRunes() : Observable<Rune[]> {
    return this.client.post<Rune[]>("http://localhost:5000/api", {}, {
      headers: { 
        'Message-Type': 'DiabloII_Cookbook.Api.Queries.GetRunesQuery, DiabloII-Cookbook.Api',
        'Content-Type': "application/json"
      }
    });
  }
}
