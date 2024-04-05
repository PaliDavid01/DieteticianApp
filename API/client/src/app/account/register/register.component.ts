import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  ListboxChangeEvent,
  ListboxSelectAllChangeEvent,
} from 'primeng/listbox';
import { AuthenticationService } from 'src/app/services/auth/authentication.service';
import {
  RegisterDTO,
  Role,
  RoleService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  onChange($event: ListboxChangeEvent) {
    throw new Error('Method not implemented.');
  }
  onSelectAllChange($event: ListboxSelectAllChangeEvent) {
    throw new Error('Method not implemented.');
  }
  model: RegisterDTO = new RegisterDTO();
  roles!: Role[];
  selectAll: boolean = false;

  constructor(
    private authService: AuthenticationService,
    private roleService: RoleService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.roleService.getRoles().subscribe({
      next: (response) => {
        this.roles = response;
      },
    });
  }

  register() {
    console.log(this.model.roles);
    this.authService.register(this.model).subscribe({
      next: () => {
        console.log('User registered');
        this.router.navigateByUrl('/');
      },
    });
  }
}
