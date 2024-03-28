import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { UserService } from 'src/app/services/generated-client';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  model:any = {};
  
  constructor(public accountService: AccountService,private userService: UserService, private router: Router){}

  login(){
    this.userService.getRoles().subscribe(
      response => console.log(response)
      );
    this.userService.login(this.model).subscribe({
      next: () => this.router.navigateByUrl('/home')
    });
  }
  register(){
    this.router.navigateByUrl('/register');
  }
}
