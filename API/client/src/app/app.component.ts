import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { Observable, of } from 'rxjs';
import { User } from './models/user';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationService } from './services/auth/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(
    public authenticationService: AuthenticationService,
    private translatorService: TranslateService
  ) {}
  ngOnInit(): void {
    this.translatorService.setDefaultLang('en');
    this.translatorService.use(localStorage.getItem('lang') || 'hu');
  }
  title = 'DietApp';
}
