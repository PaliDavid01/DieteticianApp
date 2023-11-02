import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { Observable, of } from 'rxjs';
import { User } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  constructor(public accountService: AccountService){}
  ngOnInit(): void {
    this.accountService.loadCurrentUser();
  }
  title = 'DietApp';

}
