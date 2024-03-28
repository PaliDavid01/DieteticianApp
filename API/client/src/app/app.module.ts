import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { LocalizationComponent } from './localization/localization.component';
import {TranslateModule, TranslateLoader} from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { DropdownModule } from 'primeng/dropdown';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { config } from 'rxjs';
import { RecieptContainerComponent } from './receipt/reciept-container/reciept-container.component';
import { RecieptCreateComponent } from './receipt/reciept-create/reciept-create.component';
import { RecieptUpdateComponent } from './receipt/reciept-update/reciept-update.component';
import { RecieptDisplayComponent } from './receipt/reciept-display/reciept-display.component';
import { MaterialContainerComponent } from './material/material-container/material-container.component';
import { MaterialCreateComponent } from './material/material-create/material-create.component';
import { MaterialUpdateComponent } from './material/material-update/material-update.component';
import { API_BASE_URL, RoleService, UserService } from './services/generated-client';

export function HttpLoaderFactory(http: HttpClient){
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    NavComponent,
    LocalizationComponent,
    RecieptContainerComponent,
    RecieptCreateComponent,
    RecieptUpdateComponent,
    RecieptDisplayComponent,
    MaterialContainerComponent,
    MaterialCreateComponent,
    MaterialUpdateComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    BrowserAnimationsModule,
    DropdownModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    UserService,
    RoleService,
    { provide: API_BASE_URL, useValue: 'http://localhost:7247' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
