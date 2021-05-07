import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { LoadingScreen } from './shared/models/loading-screen.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'blizzard-helper';

  constructor(public authService: OAuthService) { }

  ngOnInit(): void {
    
  }



}