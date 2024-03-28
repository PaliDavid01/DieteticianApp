import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterDTO, Role, RoleService, User, UserService } from 'src/app/services/generated-client';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model:RegisterDTO = new RegisterDTO();
  selectedRole:Role = new Role();
  roles:Array<Role> = [];
  
  constructor(private userService: UserService,private roleService: RoleService, private router: Router, private http: HttpClient){}
  ngOnInit(): void {
    this.roleService.getRoles().subscribe({
      next: response => {
        this.roles = response;
        console.log(this.roles);
      },
    });
  }

  register(){
    console.log(this.selectedRole);
    let roleid: number = this.roles.find(x => x.roleName == this.selectedRole.roleName).roleId;
    console.log(roleid);
    this.model.roleId = roleid;
    this.userService.register(this.model).subscribe({
      next: () => {
        console.log('User registered');
        this.router.navigateByUrl('/login');
      }
    });
  }
}
