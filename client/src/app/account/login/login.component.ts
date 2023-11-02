import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  model:any = {};
  
  constructor(public accountService: AccountService, private router: Router){}

  login(){
    this.accountService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/home')
    });
  }
  register(){
    this.router.navigateByUrl('/register');
  }
}
