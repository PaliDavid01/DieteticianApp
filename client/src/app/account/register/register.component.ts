import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model:any = {};
  roles:Array<string> | null = null;
  
  constructor(public accountService: AccountService, private router: Router, private http: HttpClient){}
  ngOnInit(): void {
    this.accountService.getRoles().subscribe({
      next: (response : any) => this.roles = response
    })
  }

  register(){
    this.accountService.register(this.model).subscribe({
      next: () => this.router.navigateByUrl('')
    });
  }
}
