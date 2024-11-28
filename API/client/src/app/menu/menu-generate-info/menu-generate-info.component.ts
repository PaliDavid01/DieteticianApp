import { Component } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import {
  DayMenuService,
  MealRecipe,
  MealRecipeDTO,
  MealType,
} from 'src/app/services/generated-client';

export interface GeneratedDaymenuDTO {
  data: { [key in keyof typeof MealType]: MealRecipe };
}

@Component({
  selector: 'app-menu-generate-info',
  standalone: false,
  templateUrl: './menu-generate-info.component.html',
  styleUrl: './menu-generate-info.component.css',
})
export class MenuGenerateInfoComponent {
  weekMenuId: number;
  generatedMenu: { [key in keyof typeof MealType]?: MealRecipeDTO[] };

  constructor(
    public ref: DynamicDialogRef,
    public dialogConfig: DynamicDialogConfig,
    private dayMenuService: DayMenuService
  ) {}

  ngOnInit(): void {
    this.weekMenuId = this.dialogConfig.data.weekMenuId;
    this.dayMenuService.generateDayMenu(this.weekMenuId).subscribe((data) => {
      this.generatedMenu = data;
      console.log(this.generatedMenu);
    });
  }
  save() {
    let data: GeneratedDaymenuDTO = {
      data: {
        Breakfast: new MealRecipe(),
        Brunch: new MealRecipe(),
        Lunch: new MealRecipe(),
        AfternoonSnack: new MealRecipe(),
        Dinner: new MealRecipe(),
      },
    };
    data.data.Breakfast.mealId = 0;
    data.data.Breakfast.recipeId = this.generatedMenu.Breakfast[0].recipe.recipeId;
    data.data.Breakfast.quantity = this.generatedMenu.Breakfast[0].quantity;
    data.data.Breakfast.mealRecipeId = 0;
    data.data.Brunch.mealId = 0;
    data.data.Brunch.recipeId = this.generatedMenu.Brunch[0].recipe.recipeId;
    data.data.Brunch.quantity = this.generatedMenu.Brunch[0].quantity;
    data.data.Brunch.mealRecipeId = 0;
    data.data.Lunch.mealId = 0;
    data.data.Lunch.recipeId = this.generatedMenu.Lunch[0].recipe.recipeId;
    data.data.Lunch.quantity = this.generatedMenu.Lunch[0].quantity;
    data.data.Lunch.mealRecipeId = 0;
    data.data.AfternoonSnack.mealId = 0;
    data.data.AfternoonSnack.recipeId =
      this.generatedMenu.AfternoonSnack[0].recipe.recipeId;
    data.data.AfternoonSnack.quantity =
      this.generatedMenu.AfternoonSnack[0].quantity;
    data.data.AfternoonSnack.mealRecipeId = 0;
    data.data.Dinner.mealId = 0;
    data.data.Dinner.recipeId = this.generatedMenu.Dinner[0].recipe.recipeId;
    data.data.Dinner.quantity = this.generatedMenu.Dinner[0].quantity;
    data.data.Dinner.mealRecipeId = 0;
    console.log(data);
    this.ref.close(data);
  }

  hideDialog() {
    this.ref.close;
  }
}
