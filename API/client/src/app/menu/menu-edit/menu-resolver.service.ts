import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, map, take } from 'rxjs';
import { WeekMenu, WeekMenuService } from 'src/app/services/generated-client';

@Injectable({
  providedIn: 'root',
})
export class MenuResolver implements Resolve<WeekMenu> {
  constructor(private weekMenuService: WeekMenuService) {}
  resolve(
    route: ActivatedRouteSnapshot
  ): WeekMenu | Observable<WeekMenu> | Promise<WeekMenu> {
    let id: number = Number.parseInt(route.paramMap.get('id'));
    return this.weekMenuService.getById(id).pipe(
      take(1),
      map((menu) => {
        if (menu) {
          return menu;
        } else {
          return new WeekMenu();
        }
      })
    );
  }
}
