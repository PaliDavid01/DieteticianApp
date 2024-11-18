import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './account/register/register.component';
import { MaterialContainerComponent } from './material/material-container/material-container.component';
import { AllergenComponent } from './material/allergen/allergen.component';
import { MaterialCreateComponent } from './material/material-create/material-create.component';
import { MaterialCreateResolverService } from './material/material-create/material-create-resolver.service';
import { RecipeCategoryComponent } from './recipe-ingredient/recipe-category/recipe-category.component';
import { RecipeComponent } from './recipe-ingredient/recipe/recipe.component';
import { RecipeCreateEditComponent } from './recipe-ingredient/recipe/recipe-create-edit/recipe-create-edit.component';
import { RecipeCreateEditResolverService } from './recipe-ingredient/recipe/recipe-create-edit-resolver.service';
import { MenuListComponent } from './menu/menu-list/menu-list.component';
import { MenuResolver } from './menu/menu-edit/menu-resolver.service';
import { MenuEditComponent } from './menu/menu-edit/menu-edit.component';
import { AgeCategoryComponent } from './material/age-category/age-category.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'material', component: MaterialContainerComponent },
  {
    path: 'material-edit/:id',
    component: MaterialCreateComponent,
    resolve: { material: MaterialCreateResolverService },
  },
  { path: 'allergen', component: AllergenComponent },
  { path: 'recipe', component: RecipeComponent },
  {
    path: 'recipe-edit/:id',
    component: RecipeCreateEditComponent,
    resolve: { recipe: RecipeCreateEditResolverService },
  },
  { path: 'recipe-category', component: RecipeCategoryComponent },
  { path: 'menu-list', component: MenuListComponent },
  {
    path: 'menu-edit/:id',
    component: MenuEditComponent,
    resolve: { menu: MenuResolver },
  },
  { path: 'diet-group', component: AgeCategoryComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
