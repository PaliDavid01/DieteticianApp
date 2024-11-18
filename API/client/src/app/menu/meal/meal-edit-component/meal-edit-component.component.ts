import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import {
  DialogService,
  DynamicDialogConfig,
  DynamicDialogRef,
} from 'primeng/dynamicdialog';
import { RecipeListContainerComponent } from 'src/app/recipe-ingredient/recipe/recipe-list-container/recipe-list-container.component';
import {
  GetMealRecipe,
  Meal,
  MealRecipe,
  MealRecipeService,
  MealService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-meal-edit-component',
  templateUrl: './meal-edit-component.component.html',
  styleUrl: './meal-edit-component.component.css',
  standalone: false,
})
export class MealEditComponent implements OnInit {
  meal: Meal = new Meal();
  mealRecipes: MealRecipe[] = [];
  LoadedMealRecipes: GetMealRecipe[] = [];
  constructor(
    public ref: DynamicDialogRef,
    public dialogConfig: DynamicDialogConfig,
    private mealService: MealService,
    private mealRecipeService: MealRecipeService,
    private messageService: MessageService,
    private dialogService: DialogService
  ) {}

  ngOnInit(): void {
    console.log(this.dialogConfig.data.mealId);
    if (this.dialogConfig.data.mealId > 1) {
      this.mealService
        .getById(this.dialogConfig.data.mealId)
        .subscribe((meal) => {
          this.meal = meal;
        });
      this.mealRecipeService
        .getAllDTO(this.dialogConfig.data.mealId)
        .subscribe((mealRecipes) => {
          this.LoadedMealRecipes = mealRecipes;
        });
    } else {
      this.meal = new Meal();
      this.meal.mealId = 0;
      this.meal.servingCount = 1;
      this.mealService.createWithReturnId(this.meal).subscribe((id) => {
        this.meal.mealId = id;
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Meal template created',
        });
      });
    }
  }

  // createOrEditMeal(mealId: number) {
  //   if (this.meal.mealName && this.meal.servingCount) {
  //     if (mealId > 1) {
  //       this.mealService.update(this.meal).subscribe(() => {
  //         this.messageService.add({
  //           severity: 'success',
  //           summary: 'Success',
  //           detail: 'Meal updated',
  //         });
  //         this.ref.close();
  //       });
  //     }
  //   }
  // }

  addMealRecipe() {
    let ref = this.dialogService.open(RecipeListContainerComponent, {
      header: 'Add Element',
      width: '70%',
      height: '70%',
      data: {
        mealId: this.meal.mealId,
      },
    });
    ref.onClose.subscribe(() => {
      this.mealRecipeService
        .getAllDTO(this.dialogConfig.data.mealId)
        .subscribe((mealRecipes) => {
          this.LoadedMealRecipes = mealRecipes;
        });
    });
  }

  deleteMealRecipe(mealId: any) {
    this.mealRecipeService.delete(mealId).subscribe(() => {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Element deleted',
      });
      this.mealRecipeService
        .getAllDTO(this.dialogConfig.data.mealId)
        .subscribe((mealRecipes) => {
          this.LoadedMealRecipes = mealRecipes;
        });
    });
  }
  saveMeal() {
    this.mealService.update(this.meal).subscribe(() => {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Meal Saved',
      });
    });
    this.ref.close({ mealId: this.meal.mealId });
  }
}
