import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sso-redirect',
  templateUrl: './sso-redirect.component.html',
  styleUrls: ['./sso-redirect.component.scss']
})
export class SsoRedirectComponent implements OnInit {

  constructor(private authService: OAuthService, private router: Router) { 
  }
  
  async ngOnInit() {
    await this.authService.loadDiscoveryDocumentAndTryLogin()
      .then(response => this.router.navigate(['home']));
  }

}
