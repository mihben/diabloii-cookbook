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
    return this.client.get<Array<Rune>>(`${environment.backend.url}/rune`);
  }
}
