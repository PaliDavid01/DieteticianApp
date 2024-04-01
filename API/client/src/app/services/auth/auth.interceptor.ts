import { HttpInterceptorFn } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { LoginResponseDTO } from '../generated-client';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  if (req.url.includes('login') || req.url.includes('register')) {
    return next(req);
  }
  var user: LoginResponseDTO = JSON.parse(
    sessionStorage.getItem(AuthenticationService.USER_STORAGE_KEY)
  );

  req.headers.set('Authorization', 'Bearer ' + user.token);
  return next(req);
};
