import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { User } from '../models/user';
import { Route } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  token: any;
  
  constructor(private http: HttpClient) { }

  setCurrentUser(user:User){
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  login(model:any){

    return this.http.post<User>(this.baseUrl+'User', model).pipe(
       map((response :User) =>{
          const user = response;
          if(user){
            this.setCurrentUser(user);
          }
       })
    )
  }
  register(model:any){

      return this.http.post(this.baseUrl+'User/register', model, { responseType: 'text' }).pipe(
         map((response :string) =>{
           return response;
         })
      )
    }
  getRoles(){
    return this.http.get(this.baseUrl+"User/Roles");
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  //temporary
  loadCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user')!);
    if (user) {
      this.currentUserSource.next(user);
    }
  }
}
