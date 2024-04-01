import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { AuthenticationService } from 'src/app/services/auth/authentication.service';
import { AuthService } from 'src/app/services/generated-client';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  model: any = {};

  constructor(
    public accountService: AccountService,
    private authService: AuthenticationService,
    private router: Router
  ) {}

  login() {
    this.authService.authenticate(this.model).subscribe({
      next: () => this.router.navigateByUrl('/home'),
    });
  }
  register() {
    this.router.navigateByUrl('/register');
  }
}
