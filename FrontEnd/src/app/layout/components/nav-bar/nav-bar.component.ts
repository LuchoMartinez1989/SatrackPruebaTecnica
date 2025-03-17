import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../../auth/services/auth.service';

@Component({
  selector: 'app-nav-bar',
  imports: [],
  templateUrl: './nav-bar.component.html',
  styles: ``
})


export class NavBarComponent implements OnInit {
  private authService = inject(AuthService);
  public userEmail: string | undefined = localStorage

    .getItem('email')
    ?.toString();

  public userRoles: string | undefined = localStorage
    .getItem('roles')
    ?.toString();

  ngOnInit(): void {}
  onLogOut() {
    this.authService.logout();
  }
}
