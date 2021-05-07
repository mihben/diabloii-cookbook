import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  public battleTag: string = 'my friend';

  constructor(public authService: OAuthService, private router: Router) {
  }

  ngOnInit(): void {    
  }

  public loggedIn() : boolean {
    var result = this.authService.hasValidAccessToken() && this.authService.hasValidIdToken();
    if (result) {
      console.log('I have token');
      
      const claims = this.authService.getIdentityClaims();
      if (claims) {
        this.battleTag = (claims as any)['battle_tag'];
      }
    }

    return result;
  }

  public login() {
    this.authService.loadDiscoveryDocumentAndLogin()
    .then((response) => {
      if (!this.authService.hasValidIdToken() || !this.authService.hasValidAccessToken()) {
        this.authService.initCodeFlow();
      }
    })
    .catch((err) => {
      console.log(err);
    });
  }

  public logout() {
    this.authService.logOut();
    this.battleTag = 'my friend'
  }
}
