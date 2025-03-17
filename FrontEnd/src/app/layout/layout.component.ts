import { Component } from '@angular/core';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import SideMenuComponent from './components/side-menu/side-menu.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet, NavBarComponent, SideMenuComponent],
  templateUrl: './layout.component.html',
  styles: ``,
})
export default class LayoutComponent {}
