import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { Observable, of } from 'rxjs';
import { User } from './models/user';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  constructor(public accountService: AccountService, private translatorService: TranslateService){}
  ngOnInit(): void {
    this.accountService.loadCurrentUser();
    this.translatorService.setDefaultLang('en');
    this.translatorService.use(localStorage.getItem('lang') || 'hu');
  }
  title = 'DietApp';

}
