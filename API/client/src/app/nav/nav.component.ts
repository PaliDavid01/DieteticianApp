import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '../models/user';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/auth/authentication.service';
import { MenuItem } from 'primeng/api';
import { PrimeIcons } from 'primeng/api';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  curentUser$: Observable<User | null> = of(null);
  items: MenuItem[];
  constructor(
    public authenticationService: AuthenticationService,
    private translateService: TranslateService,
    private router: Router
  ) {}

  ngOnInit() {
    this.items = [
      {
        label: 'Base data',
        id: 'basedata',
        icon: PrimeIcons.FILE,
        items: [
          {
            label: 'Allergen',
            id: 'allergen',
            icon: PrimeIcons.CIRCLE_FILL,
            url: '/allergen',
          },
          {
            label: this.translateService.instant('baseMaterial'),
            icon: PrimeIcons.BOX,
            url: '/material',
          },
          {
            label: 'Diet groups',
            icon: PrimeIcons.USERS,
            url: '/diet-group',
          },
        ],
      },
      {
        label: 'Recipes',
        icon: 'pi pi-fw pi-pencil',
        items: [
          {
            label: 'Recipe categories',
            icon: 'pi pi-fw pi-bars',
            url: '/recipe-category',
          },
          {
            label: 'Recipes',
            icon: 'pi pi-fw pi-file-edit',
            url: '/recipe',
          },
          {
            label: 'Center',
            icon: 'pi pi-fw pi-align-center',
          },
          {
            label: 'Justify',
            icon: 'pi pi-fw pi-align-justify',
          },
        ],
      },
      {
        label: 'Users',
        icon: 'pi pi-fw pi-user',
        items: [
          {
            label: 'New',
            icon: 'pi pi-fw pi-user-plus',
          },
          {
            label: 'Delete',
            icon: 'pi pi-fw pi-user-minus',
          },
          {
            label: 'Search',
            icon: 'pi pi-fw pi-users',
            items: [
              {
                label: 'Filter',
                icon: 'pi pi-fw pi-filter',
                items: [
                  {
                    label: 'Print',
                    icon: 'pi pi-fw pi-print',
                  },
                ],
              },
              {
                icon: 'pi pi-fw pi-bars',
                label: 'List',
              },
            ],
          },
        ],
      },
      {
        label: 'Menus',
        icon: 'pi pi-fw pi-table',
        items: [
          {
            label: 'List',
            icon: 'pi pi-fw pi-list',
            url: '/menu-list',
          },
          {
            label: 'Archieve',
            icon: 'pi pi-fw pi-calendar-times',
            items: [
              {
                label: 'Remove',
                icon: 'pi pi-fw pi-calendar-minus',
              },
            ],
          },
        ],
      },
      {
        label: this.translateService.instant('logOut'),
        icon: 'pi pi-fw pi-power-off',
        command: () => this.logout(),
      },
    ];
  }
  logout() {
    this.authenticationService.clearSession();
    this.router.navigateByUrl('/');
  }
}
