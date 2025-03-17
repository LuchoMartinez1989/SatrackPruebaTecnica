import { Component, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

interface SideMenuOptions {
  name: string;
  subName: string;
  icon: string;
  route: string;
}

@Component({
  selector: 'app-side-menu',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './side-menu.component.html',
  styles: ``,
})
export default class SideMenuComponent {
  menuOptions = signal<SideMenuOptions[]>([
    {
      name: 'Clientes',
      subName: '',
      icon: 'fa-solid fa-chart-simple',
      route: '/clients',
    },
    {
      name: 'CrearClientes',
      subName: 'Find GIFs',
      icon: 'fa-solid fa-magnifying-glass',
      route: '/clientsCreate',
    },
  ]);
}
