import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
} from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { LocalizationComponent } from './localization/localization.component';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialContainerComponent } from './material/material-container/material-container.component';
import { MaterialCreateComponent } from './material/material-create/material-create.component';
import {
  API_BASE_URL,
  AgeCategory,
  AgeCategoryService,
  AllergenCustomer,
  AllergenCustomerService,
  AllergenService,
  AuthService,
  BaseMaterial,
  BaseMaterialService,
  Customer,
  CustomerService,
  DayMenuService,
  DayOrder,
  DayOrderService,
  Ingredient,
  IngredientService,
  Meal,
  MealRecipeService,
  MealService,
  Order,
  OrderService,
  OrderWeekMenuService,
  Recipe,
  RecipeCategory,
  RecipeCategoryService,
  RecipeService,
  RoleService,
  WeekMenuGenerateDataAllergenService,
  WeekMenuGenerateDataService,
  WeekMenuService,
  WeekOrderService,
} from './services/generated-client';
import { AuthInterceptor } from './services/auth/auth.interceptor';

// PrimeNG
// Import PrimeNG modules
import { AccordionModule } from 'primeng/accordion';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';
import { BadgeModule } from 'primeng/badge';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CarouselModule } from 'primeng/carousel';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { ChartModule } from 'primeng/chart';
import { CheckboxModule } from 'primeng/checkbox';
import { ChipModule } from 'primeng/chip';
import { ChipsModule } from 'primeng/chips';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { ColorPickerModule } from 'primeng/colorpicker';
import { ContextMenuModule } from 'primeng/contextmenu';
import { DataViewModule } from 'primeng/dataview';
import { VirtualScrollerModule } from 'primeng/virtualscroller';
import { DialogModule } from 'primeng/dialog';
import { DividerModule } from 'primeng/divider';
import { DockModule } from 'primeng/dock';
import { DragDropModule } from 'primeng/dragdrop';
import { DropdownModule } from 'primeng/dropdown';
import { DialogService, DynamicDialogModule } from 'primeng/dynamicdialog';
import { EditorModule } from 'primeng/editor';
import { FieldsetModule } from 'primeng/fieldset';
import { FileUploadModule } from 'primeng/fileupload';
import { GalleriaModule } from 'primeng/galleria';
import { InplaceModule } from 'primeng/inplace';
import { InputMaskModule } from 'primeng/inputmask';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputOtpModule } from 'primeng/inputotp';
import { ImageModule } from 'primeng/image';
import { KnobModule } from 'primeng/knob';
import { ListboxModule } from 'primeng/listbox';
import { MegaMenuModule } from 'primeng/megamenu';
import { MenuModule } from 'primeng/menu';
import { MenubarModule } from 'primeng/menubar';
import { MessageModule } from 'primeng/message';
import { MessagesModule } from 'primeng/messages';
import { MultiSelectModule } from 'primeng/multiselect';
import { MeterGroupModule } from 'primeng/metergroup';
import { OrderListModule } from 'primeng/orderlist';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { PaginatorModule } from 'primeng/paginator';
import { PanelModule } from 'primeng/panel';
import { PanelMenuModule } from 'primeng/panelmenu';
import { PasswordModule } from 'primeng/password';
import { PickListModule } from 'primeng/picklist';
import { ProgressBarModule } from 'primeng/progressbar';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RatingModule } from 'primeng/rating';
import { ScrollerModule } from 'primeng/scroller';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { ScrollTopModule } from 'primeng/scrolltop';
import { SelectButtonModule } from 'primeng/selectbutton';
import { SidebarModule } from 'primeng/sidebar';
import { SkeletonModule } from 'primeng/skeleton';
import { SlideMenuModule } from 'primeng/slidemenu';
import { SliderModule } from 'primeng/slider';
import { SpeedDialModule } from 'primeng/speeddial';
import { SpinnerModule } from 'primeng/spinner';
import { SplitButtonModule } from 'primeng/splitbutton';
import { SplitterModule } from 'primeng/splitter';
import { StepperModule } from 'primeng/stepper';
import { StepsModule } from 'primeng/steps';
import { TabMenuModule } from 'primeng/tabmenu';
import { TableModule, TableService } from 'primeng/table';
import { TabViewModule } from 'primeng/tabview';
import { TagModule } from 'primeng/tag';
import { TerminalModule } from 'primeng/terminal';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { TimelineModule } from 'primeng/timeline';
import { ToastModule } from 'primeng/toast';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { ToolbarModule } from 'primeng/toolbar';
import { TooltipModule } from 'primeng/tooltip';
import { TriStateCheckboxModule } from 'primeng/tristatecheckbox';
import { TreeModule } from 'primeng/tree';
import { TreeSelectModule } from 'primeng/treeselect';
import { TreeTableModule } from 'primeng/treetable';
import { AnimateModule } from 'primeng/animate';
import { Card, CardModule } from 'primeng/card';
import { BlockUIModule } from 'primeng/blockui';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { RippleModule } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { ConfirmationService, MessageService } from 'primeng/api';
import { SharedModule } from 'primeng/api';

// Import AllergenComponent
import { AllergenComponent } from './material/allergen/allergen.component';
import { MaterialCreateResolverService } from './material/material-create/material-create-resolver.service';
import { RecipeComponent } from './recipe-ingredient/recipe/recipe.component';
import { RecipeCategoryComponent } from './recipe-ingredient/recipe-category/recipe-category.component';
import { RecipeCreateEditComponent } from './recipe-ingredient/recipe/recipe-create-edit/recipe-create-edit.component';
import { MenuListComponent } from './menu/menu-list/menu-list.component';
import { MealComponentComponent } from './menu/menu-shared/meal-component/meal-component.component';
import { MenuEditComponent } from './menu/menu-edit/menu-edit.component';
import { MealEditComponent } from './menu/meal/meal-edit-component/meal-edit-component.component';
import { RecipeListContainerComponent } from './recipe-ingredient/recipe/recipe-list-container/recipe-list-container.component';
import { MealInfoCardComponent } from './menu/meal/meal-info-card/meal-info-card.component';
import { MenuGenerateModalComponent } from './menu/menu-generate-modal/menu-generate-modal.component';
import { AgeCategoryComponent } from './material/age-category/age-category.component';
import { MenuGenerateInfoComponent } from './menu/menu-generate-info/menu-generate-info.component';
import { CustomerListComponent } from './customer/customer-list/customer-list.component';
import { OrderEditModalComponent } from './customer/order-edit-modal/order-edit-modal.component';
import { CustomDateFormatPipe } from './pipes/custom-date-format.pipe';
import { OrderWeekEditModalComponent } from './customer/order-week-edit-modal/order-week-edit-modal.component';

export function HttpLoaderFactory(http: HttpClient) {
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
    MaterialContainerComponent,
    MaterialCreateComponent,
    AllergenComponent,
    RecipeCategoryComponent,
    RecipeComponent,
    RecipeCreateEditComponent,
    MenuListComponent,
    MealComponentComponent,
    MenuEditComponent,
    MealEditComponent,
    RecipeListContainerComponent,
    MealInfoCardComponent,
    MenuGenerateModalComponent,
    AgeCategoryComponent,
    MenuGenerateInfoComponent,
    CustomerListComponent,
    OrderEditModalComponent,
    CustomDateFormatPipe,
    OrderWeekEditModalComponent,
  ],
  exports: [CustomDateFormatPipe],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    MultiSelectModule,
    // PrimeNG
    AvatarModule,
    AvatarGroupModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AccordionModule,
    AutoCompleteModule,
    BadgeModule,
    BreadcrumbModule,
    BlockUIModule,
    ButtonModule,
    CalendarModule,
    CardModule,
    CarouselModule,
    CascadeSelectModule,
    ChartModule,
    CheckboxModule,
    ChipsModule,
    ChipModule,
    ColorPickerModule,
    ConfirmDialogModule,
    ConfirmPopupModule,
    ContextMenuModule,
    VirtualScrollerModule,
    DataViewModule,
    DialogModule,
    DividerModule,
    DockModule,
    DragDropModule,
    DropdownModule,
    DynamicDialogModule,
    EditorModule,
    FieldsetModule,
    FileUploadModule,
    GalleriaModule,
    InplaceModule,
    InputMaskModule,
    InputSwitchModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    InputGroupModule,
    InputGroupAddonModule,
    InputOtpModule,
    ImageModule,
    KnobModule,
    ListboxModule,
    MegaMenuModule,
    MenuModule,
    MenubarModule,
    MessageModule,
    MessagesModule,
    MultiSelectModule,
    MeterGroupModule,
    OrganizationChartModule,
    OrderListModule,
    OverlayPanelModule,
    PaginatorModule,
    PanelModule,
    PanelMenuModule,
    PasswordModule,
    PickListModule,
    ProgressSpinnerModule,
    ProgressBarModule,
    RadioButtonModule,
    RatingModule,
    SelectButtonModule,
    SidebarModule,
    ScrollerModule,
    ScrollPanelModule,
    ScrollTopModule,
    SkeletonModule,
    SlideMenuModule,
    SliderModule,
    SpeedDialModule,
    SpinnerModule,
    SplitterModule,
    StepperModule,
    SplitButtonModule,
    StepsModule,
    TableModule,
    TabMenuModule,
    TabViewModule,
    TagModule,
    TerminalModule,
    TieredMenuModule,
    TimelineModule,
    ToastModule,
    ToggleButtonModule,
    ToolbarModule,
    TooltipModule,
    TriStateCheckboxModule,
    TreeModule,
    TreeSelectModule,
    TreeTableModule,
    AnimateModule,
    RippleModule,
    StyleClassModule,
    SharedModule,
    //end PrimeNG
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
    BrowserAnimationsModule,
    DropdownModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [
    AuthService,
    RoleService,
    AllergenService,
    MessageService,
    DialogService,
    TableService,
    BaseMaterialService,
    ConfirmationService,
    MaterialCreateResolverService,
    ConfirmationService,
    RecipeCategoryService,
    RecipeService,
    IngredientService,
    // services ftom the generated service file that hasnt been imported
    WeekMenuService,
    WeekOrderService,
    DayMenuService,
    DayOrderService,
    MealService,
    MealRecipeService,
    CustomerService,
    WeekMenuGenerateDataAllergenService,
    WeekMenuGenerateDataService,
    AgeCategoryService,
    AllergenCustomerService,
    OrderWeekMenuService,
    OrderService,
    DatePipe,

    { provide: API_BASE_URL, useValue: 'http://localhost:7247' },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
