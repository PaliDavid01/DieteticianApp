import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<any>(null);
  currentUser$ = this.currentUserSource.asObservable();
  token: any;
  
  constructor(private http: HttpClient) { }

  setCurrentUser(){

  }

  login(model:any){

    return this.http.post(this.baseUrl+'User', model, { responseType: 'text' }).pipe(
       map((response :string) =>{
         return response;
       })
    )}
}
