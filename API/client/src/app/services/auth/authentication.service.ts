import { Inject, Injectable, Optional } from '@angular/core';
import {
  API_BASE_URL,
  AuthService,
  LoginDTO,
  LoginResponseDTO,
  RegisterDTO,
} from '../generated-client';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService extends AuthService {
  static USER_STORAGE_KEY: string = 'USER_INFO';

  constructor(
    http: HttpClient,
    @Optional() @Inject(API_BASE_URL) baseUrl?: string
  ) {
    super(http, baseUrl);
  }

  get user(): LoginResponseDTO {
    let user = sessionStorage.getItem(AuthenticationService.USER_STORAGE_KEY);
    if (user && user !== 'undefined') {
      return JSON.parse(user);
    }
    return null;
  }
  getIsAuthenticated(): boolean {
    return this.user !== null && this.user !== undefined;
  }
  getAuthorizationToken(): string {
    return this.user.token;
  }
  clearSession(): void {
    sessionStorage.removeItem(AuthenticationService.USER_STORAGE_KEY);
  }
  authenticate(loginDTO: LoginDTO) {
    return super.login(loginDTO).pipe(
      map((response: LoginResponseDTO) => {
        if (response) {
          sessionStorage.setItem(
            AuthenticationService.USER_STORAGE_KEY,
            JSON.stringify(response)
          );
          console.log(loginDTO, response);
        } else {
          this.clearSession();
        }
        return response;
      })
    );
  }
  override register(userDTO: RegisterDTO): Observable<LoginResponseDTO> {
    return super.register(userDTO).pipe(
      map((response: LoginResponseDTO) => {
        if (response) {
          sessionStorage.setItem(
            AuthenticationService.USER_STORAGE_KEY,
            JSON.stringify(response)
          );
        } else {
          this.clearSession();
        }
        return response;
      })
    );
  }
}
