import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './account/register/register.component';
import { RecieptContainerComponent } from './receipt/reciept-container/reciept-container.component';
import { MaterialContainerComponent } from './material/material-container/material-container.component';
import { AllergenComponent } from './material/allergen/allergen.component';
import { MaterialCreateComponent } from './material/material-create/material-create.component';
import { MaterialCreateResolverService } from './material/material-create/material-create-resolver.service';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'reciept', component: RecieptContainerComponent },
  { path: 'material', component: MaterialContainerComponent },
  {
    path: 'material-edit/:id',
    component: MaterialCreateComponent,
    resolve: { material: MaterialCreateResolverService },
  },
  { path: 'allergen', component: AllergenComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
