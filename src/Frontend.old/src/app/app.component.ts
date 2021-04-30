import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { authConfig } from './app.module';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'diabloii-cookbook';

  constructor(private authService: OAuthService, private router: Router) {
    this.authService.configure(authConfig);
  }

  ngOnInit(): void {
    this.authService.loadDiscoveryDocumentAndTryLogin()
      .then((response) => {
        if (!this.authService.hasValidIdToken() || !this.authService.hasValidAccessToken()) {
          this.authService.initCodeFlow();
        } else {
          this.router.navigate(['/diabloii']);
        }
      })
      .catch((err) => {
        console.log(err);
      });
  }
}
