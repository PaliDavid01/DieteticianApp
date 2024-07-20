import { Component, HostBinding, OnInit, signal } from '@angular/core';
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
  themes: string[] = ['light', 'dark'];
  selectedTheme: string;
  title = 'DietApp';
  constructor(
    public authenticationService: AuthenticationService,
    private translatorService: TranslateService
  ) {}
  ngOnInit(): void {
    this.translatorService.setDefaultLang('en');
    this.translatorService.use(localStorage.getItem('lang') || 'hu');
    this.initTheme();
  }
  initTheme() {
    if (localStorage.getItem('theme')) {
      this.selectedTheme = localStorage.getItem('theme');
    } else {
      const deviceMode = window.matchMedia('(prefers-color-scheme: dark)');
      if (deviceMode.matches) {
        this.selectedTheme = 'dark';
      } else {
        this.selectedTheme = 'light';
      }
      localStorage.setItem('theme', this.selectedTheme);
    }
    let themeLink = document.getElementById('app-theme') as HTMLLinkElement;
    if (this.selectedTheme === 'dark') {
      themeLink.href = 'lara-dark-blue.css';
    } else {
      themeLink.href = 'lara-light-blue.css';
    }
  }
}
