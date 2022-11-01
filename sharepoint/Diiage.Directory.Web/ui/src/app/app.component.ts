import { AuthentificationService } from './services/authentification.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {

  public profile: any;

  ngOnInit() {
    this.login()
  }

  constructor (private authentificationService: AuthentificationService, private router: Router) { }

  login() {
    this.authentificationService.login().then(() => {
      this.authentificationService.getProfile().then(profile => {
        this.profile = profile
        this.authentificationService.logTrace('connexion du client ' + this.profile.displayName);
        this.authentificationService.logPageView('page view' + this.router.url)
      })
    }).catch(error => {
      console.log(error)
    })
  }
}
