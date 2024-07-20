import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  MaybeAsync,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable, map, take } from 'rxjs';
import { Recipe, RecipeService } from 'src/app/services/generated-client';

@Injectable({
  providedIn: 'root',
})
export class RecipeCreateEditResolverService implements Resolve<Recipe> {
  constructor(private recipeService: RecipeService) {}
  resolve(
    route: ActivatedRouteSnapshot
  ): Recipe | Observable<Recipe> | Promise<Recipe> {
    let id: number = Number.parseInt(route.paramMap.get('id'));
    return this.recipeService.getById(id).pipe(
      take(1),
      map((recipe) => {
        if (recipe) {
          return recipe;
        } else {
          return new Recipe();
        }
      })
    );
  }
}
