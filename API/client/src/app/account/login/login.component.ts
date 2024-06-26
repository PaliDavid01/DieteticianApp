import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AccountService } from 'src/app/services/account.service';
import { AuthenticationService } from 'src/app/services/auth/authentication.service';
import { AuthService, LoginDTO } from 'src/app/services/generated-client';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  model: LoginDTO = new LoginDTO();
  constructor(
    public accountService: AccountService,
    private authService: AuthenticationService,
    private router: Router,
    private translator: TranslateService
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
