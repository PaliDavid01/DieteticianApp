import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  curentUser$: Observable<User|null> = of(null);
  constructor(public accountService:AccountService, private router: Router){}
  
  ngOnInit(): void {
     this.curentUser$ = this.accountService.currentUser$;
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
  
}
