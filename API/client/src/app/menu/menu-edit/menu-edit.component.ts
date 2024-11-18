import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogService } from 'primeng/dynamicdialog';
import {
  DayMenu,
  DayMenuService,
  WeekMenu,
  WeekMenuGenerateDataAllergenService,
  WeekMenuGenerateDataService,
  WeekMenuService,
} from 'src/app/services/generated-client';
import { MealEditComponent } from '../meal/meal-edit-component/meal-edit-component.component';
import { first } from 'rxjs';
import { MessageService } from 'primeng/api';
import { MenuGenerateModalComponent } from '../menu-generate-modal/menu-generate-modal.component';

@Component({
  selector: 'app-menu-edit',
  standalone: false,
  templateUrl: './menu-edit.component.html',
  styleUrl: './menu-edit.component.css',
})
export class MenuEditComponent implements OnInit {
  range: number[] = Array.from({ length: 7 }, (_, i) => i);
  weekMenu: WeekMenu = new WeekMenu();
  dayMenus: Map<number, DayMenu> = new Map();
  DaysOfWeek = [
    'Monday',
    'Tuesday',
    'Wednesday',
    'Thursday',
    'Friday',
    'Saturday',
    'Sunday',
  ];
  initEditBtnLabel = 'Initialize';
  generateData: { ageCategoryId: number; allergens: number[] };

  MealsOfDay = ['Breakfast', 'Brunch', 'Lunch', 'Afternoon Snack', 'Dinner'];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private weekMenuService: WeekMenuService,
    private dayMenuService: DayMenuService,
    private dialogService: DialogService,
    private messageService: MessageService,
    private weekMenuGenerateDataService: WeekMenuGenerateDataService,
    private weelMenuGenerateDataAllergenService: WeekMenuGenerateDataAllergenService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.weekMenu = data['menu'];
    });
    if (this.weekMenu.weekMenuId > 0) {
      this.initEditBtnLabel = 'Save';
      this.loadDayMenus();
    } else {
    }
  }

  loadDayMenus() {
    if (this.weekMenu.mondayId > 1) {
      this.dayMenuService
        .getById(this.weekMenu.mondayId)
        .subscribe((dayMenu) => {
          this.dayMenus.set(0, dayMenu);
        });
    }
    if (this.weekMenu.tuesdayId > 1) {
      this.dayMenuService
        .getById(this.weekMenu.tuesdayId)
        .subscribe((dayMenu) => {
          this.dayMenus.set(1, dayMenu);
        });
    }
    if (this.weekMenu.wednesdayId > 1) {
      this.dayMenuService
        .getById(this.weekMenu.wednesdayId)
        .subscribe((dayMenu) => {
          this.dayMenus.set(2, dayMenu);
        });
    }
    if (this.weekMenu.thursdayId > 1) {
      this.dayMenuService
        .getById(this.weekMenu.thursdayId)
        .subscribe((dayMenu) => {
          this.dayMenus.set(3, dayMenu);
        });
    }
    if (this.weekMenu.fridayId > 1) {
      this.dayMenuService
        .getById(this.weekMenu.fridayId)
        .subscribe((dayMenu) => {
          this.dayMenus.set(4, dayMenu);
        });
    }
    if (this.weekMenu.saturdayId > 1) {
      this.dayMenuService
        .getById(this.weekMenu.saturdayId)
        .subscribe((dayMenu) => {
          this.dayMenus.set(5, dayMenu);
        });
    }
    if (this.weekMenu.sundayId > 1) {
      this.dayMenuService
        .getById(this.weekMenu.sundayId)
        .subscribe((dayMenu) => {
          this.dayMenus.set(6, dayMenu);
        });
    }
    this.generateData = { ageCategoryId: 0, allergens: [] };
    this.loadGenerateData();
  }

  loadGenerateData() {
    this.weekMenuGenerateDataService
      .getByWeekMenuId(this.weekMenu.weekMenuId)
      .subscribe((data) => {
        if (data) {
          this.generateData.ageCategoryId = data.ageCategoryId;
        }
      });
    this.weelMenuGenerateDataAllergenService
      .getByWeekMenuGenerateDataId(this.weekMenu.weekMenuId)
      .subscribe((data) => {
        if (data.length > 0) {
          this.generateData.allergens = data.map(
            (allergen) => allergen.allergenId
          );
        }
      });
  }

  initOrEdit() {
    if (!this.weekMenu.weekMenuId) {
      this.weekMenu.weekMenuId = 0;
      this.weekMenu.mondayId = 0;
      this.weekMenu.tuesdayId = 0;
      this.weekMenu.wednesdayId = 0;
      this.weekMenu.thursdayId = 0;
      this.weekMenu.fridayId = 0;
      this.weekMenu.saturdayId = 0;
      this.weekMenu.sundayId = 0;
      this.weekMenuService.initWeekMenu(this.weekMenu).subscribe((data) => {
        this.router.navigate(['menu-edit', data.weekMenuId]);
      });
    } else {
      this.weekMenuService.update(this.weekMenu).subscribe(() => {
        this.router.navigate(['menu-edit', this.weekMenu.weekMenuId]);
      });
    }
  }

  addOrEditMeal(
    id: number,
    dayMenuId: number,
    mealOfDay: string,
    dayOfWeekIndex: number
  ) {
    if (id) {
      let ref = this.dialogService.open(MealEditComponent, {
        width: '80%',
        height: '85%',
        header: id != 1 ? 'Edit Meal' : 'Create Meal',
        closeOnEscape: false,
        closable: false,
        data: {
          mealId: id,
        },
      });
      ref.onClose.subscribe((data) => {
        console.log(data.mealId, dayMenuId, mealOfDay, dayOfWeekIndex);
        this.insertMealId(data.mealId, dayMenuId, mealOfDay, dayOfWeekIndex);
        this.router.navigate(['menu-edit', this.weekMenu.weekMenuId]);
      });
    }
  }

  insertMealId(
    mealId: number,
    dayMenuId: number,
    mealOfDay: string,
    dayOfWeekIndex: number
  ) {
    let daymenu = this.dayMenus.get(dayOfWeekIndex);
    switch (mealOfDay) {
      case 'Breakfast':
        daymenu.breakfastId = mealId;
        this.dayMenuService.update(daymenu).subscribe(() => {
          this.dayMenus.set(dayOfWeekIndex, daymenu);
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Breakfast added',
          });
        });
        break;
      case 'Brunch':
        daymenu.brunchId = mealId;
        this.dayMenuService.update(daymenu).subscribe(() => {
          this.dayMenus.set(dayOfWeekIndex, daymenu);
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Brunch added',
          });
        });
        break;
      case 'Lunch':
        daymenu.lunchId = mealId;
        this.dayMenuService.update(daymenu).subscribe(() => {
          this.dayMenus.set(dayOfWeekIndex, daymenu);
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Lunch added',
          });
        });
        break;
      case 'Afternoon Snack':
        daymenu.afternoonSnackId = mealId;
        this.dayMenuService.update(daymenu).subscribe(() => {
          this.dayMenus.set(dayOfWeekIndex, daymenu);
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Afternoon Snack added',
          });
        });
        break;
      case 'Dinner':
        daymenu.dinnerId = mealId;
        this.dayMenuService.update(daymenu).subscribe(() => {
          this.dayMenus.set(dayOfWeekIndex, daymenu);
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Dinner added',
          });
        });
        break;
    }
  }

  showGenerateDataDialog() {
    let ref = this.dialogService.open(MenuGenerateModalComponent, {
      header: 'Generate Menu',
      width: '20%',
      height: '55%',
      data: {
        weekMenuId: this.weekMenu.weekMenuId,
      },
    });
    ref.onClose.subscribe((data) => {
      this.generateData = data;
    });
  }
}
