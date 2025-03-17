import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { User } from '../interfaces/auth-user-response.interface';
import { AuthStatus } from '../enums/auth-status.enum';
import { catchError, map, Observable, of, throwError } from 'rxjs';
import { AuthLoginResponse } from '../interfaces/auth-login-response.inteface';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http=inject(HttpClient)
  private readonly baseUrl=environment.baseUrl;
  private _currentUser =signal<User|null>(null);
  private _authStatus=signal<AuthStatus>(AuthStatus.checking)
  public currentuser =computed(()=>this._currentUser())
  public authStatus =computed(()=>this._authStatus())


  constructor() {
      this.checkAuthStatus().subscribe();

   }

  private setAuthentication(user: User): boolean {
    this._currentUser.set(user);
    this._authStatus.set(AuthStatus.authenticated);
    localStorage.setItem('email', user.email);
    localStorage.setItem('roles', user.roles.toString());
    localStorage.setItem('token', user.jwToken);

    return true;
  }

login(email: string, password: string): Observable<boolean> {
  const url = `${this.baseUrl}/Account/authenticate`;
  const body = { email, password };

  return this.http.post<AuthLoginResponse>(url, body).pipe(
    map((resp) => {console.log(resp)
       return this.setAuthentication(resp.data)}, ),
    catchError((err) => {
      return throwError(() => err.error.Message);
    })
  );
}


//crear cuenta
register(email: string, password: string) {}


//verificar el token en local storage
checkAuthStatus(): Observable<boolean> {
  const token = localStorage.getItem('token');
  if (!token) {
    this.logout();
    return of(false);
  } else {
    this._authStatus.set(AuthStatus.authenticated);
    return of(true);
  }
}

// metodo para generar el deslogue
logout() {
  localStorage.removeItem('email');
  localStorage.removeItem('roles');
  localStorage.removeItem('token');
  this._currentUser.set(null);
  this._authStatus.set(AuthStatus.notAuthenticated);
}


}
