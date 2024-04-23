import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, MaybeAsync, Resolve } from '@angular/router';
import { Observable, map, take } from 'rxjs';
import {
  BaseMaterial,
  BaseMaterialService,
} from 'src/app/services/generated-client';

@Injectable({
  providedIn: 'root',
})
export class MaterialCreateResolverService implements Resolve<BaseMaterial> {
  constructor(private baseMaterialService: BaseMaterialService) {}
  resolve(
    route: ActivatedRouteSnapshot
  ): BaseMaterial | Observable<BaseMaterial> | Promise<BaseMaterial> {
    let id: number = Number.parseInt(route.paramMap.get('id'));
    return this.baseMaterialService.getById(id).pipe(
      take(1),
      map((material) => {
        if (material) {
          return material;
        } else {
          return new BaseMaterial();
        }
      })
    );
  }
}
