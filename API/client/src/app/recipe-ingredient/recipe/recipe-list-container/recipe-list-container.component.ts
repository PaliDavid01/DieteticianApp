import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import {
  MealRecipe,
  MealRecipeService,
  Recipe,
  RecipeService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-recipe-list-container',
  standalone: false,
  templateUrl: './recipe-list-container.component.html',
  styleUrl: './recipe-list-container.component.css',
})
export class RecipeListContainerComponent {
  displayDialog: boolean = false;
  displayAddRecipeDialog: boolean = false;
  selectedRecipes: any;
  Delete: string = 'Delete';
  recipe: Recipe;
  recipes!: Recipe[];
  clickedRecipeId!: number;
  quantity: number = 1;
  constructor(
    private recipeService: RecipeService,
    private messageService: MessageService,
    private router: Router,
    private confirmationService: ConfirmationService,
    public dialogConfig: DynamicDialogConfig,
    public ref: DynamicDialogRef,
    private mealRecipeService: MealRecipeService
  ) {}
  ngOnInit(): void {
    this.loadRecipes();
  }

  addClicked(id: number) {
    this.displayAddRecipeDialog = true;
    this.clickedRecipeId = id;
  }

  hideAddDialog() {
    this.displayAddRecipeDialog = false;
  }

  hideDialog() {
    this.displayDialog = false;
  }

  loadRecipes() {
    this.recipeService.readAll().subscribe((data) => {
      this.recipes = data;
    });
  }

  showInfo(item: Recipe) {
    this.recipe = item;
    this.displayDialog = true;
  }
  closeDialog() {
    this.ref.close();
  }
  save() {
    this.displayAddRecipeDialog = false;
    if (this.quantity <= 1) {
      let mealRecipe = new MealRecipe();
      mealRecipe.mealRecipeId = 0;
      mealRecipe.recipeId = this.clickedRecipeId;
      mealRecipe.quantity = 1;
      mealRecipe.mealId = this.dialogConfig.data.mealId;
      this.mealRecipeService.create(mealRecipe).subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Element added to meal',
        });
      });
      this.ref.close();
    }
  }
}
