import { Routes } from '@angular/router';
import { isNotAuthenticatedGuard } from './auth/guards/is-not-authenticated.guard';
import { isAuthenticatedGuard } from './auth/guards/is-authenticated.guard';

export const routes: Routes = [
  {
    path: 'layout',
    canActivate:[isAuthenticatedGuard],
    loadComponent: () => import('./layout/layout.component'),
    children: [
      {
        path: 'clients',
        loadComponent: () =>
          import('./client/pages/clients-list/clients-list.component'),
      },
      {
        path: 'clientsCreate',
        loadComponent: () =>
          import('./client/pages/clients-create/clients-create.component'),
      },
      {
        path: '**',
        redirectTo: 'clients',
      },
    ],
  },
  {
    path: 'auth',
    canActivate:[isNotAuthenticatedGuard],
    loadComponent: () => import('./auth/auth-layout/auth-layout.component'),
    children: [
      {
        path: 'login',
        loadComponent: () => import('./auth/auth-login/auth-login.component'),
      },
      {
        path: 'register',
        loadComponent: () =>
          import('./auth/auth-register/auth-register.component'),
      },
      {
        path: '**',
        redirectTo: 'login',
      },
    ],
  },
  {
    path:'**',
    redirectTo:'auth'
  }

];
