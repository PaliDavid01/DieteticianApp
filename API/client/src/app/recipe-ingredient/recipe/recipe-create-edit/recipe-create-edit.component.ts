import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import {
  BaseMaterial,
  BaseMaterialService,
  Ingredient,
  IngredientDataView,
  IngredientService,
  Recipe,
  RecipeCategory,
  RecipeCategoryService,
  RecipeService,
} from 'src/app/services/generated-client';
import { CardModule } from 'primeng/card';
import { EMPTY, catchError } from 'rxjs';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-recipe-create-edit',
  templateUrl: './recipe-create-edit.component.html',
  styleUrl: './recipe-create-edit.component.css',
  standalone: false,
})
export class RecipeCreateEditComponent {
  @ViewChild('dt') dt: Table;
  ingredientToAddDialog: boolean;
  selectedMaterialToCreateIngredient: BaseMaterial;
  recipe: Recipe;
  title: string;
  recipeForm: FormGroup<any>;
  isSubmitted: boolean;
  ingredientViews: IngredientDataView[];
  ingredients: Ingredient[];
  baseMaterials: BaseMaterial[];
  ingredientToAdd: Ingredient = new Ingredient();
  displayEditIngredientDialog: boolean;
  recipeCategories: RecipeCategory[];
  categories: RecipeCategory[];
  selectedRecipeCategory: RecipeCategory;

  constructor(
    private route: ActivatedRoute,
    private baseMaterialService: BaseMaterialService,
    private messageService: MessageService,
    private recipeService: RecipeService,
    private ingredientService: IngredientService,
    private recipeCategoryService: RecipeCategoryService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.recipe = data['recipe'];
    });
    this.loadRecipeCategories();
    console.log(this.recipeCategories);
    if (this.recipe.recipeId) {
      this.title = 'Edit Recipe';
      this.loadIngredientViews(this.recipe.recipeId);
      this.loadIngredients(this.recipe.recipeId);
    } else {
      this.title = 'Create Recipe';
    }
    this.loadBaseMaterials();
  }

  deleteIngredient(item: IngredientDataView) {
    this.ingredientService.delete(item.ingredientId).subscribe(() => {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Ingredient deleted',
        life: 3000,
      });
      this.recipeService.recalculateMacros(this.recipe.recipeId).subscribe();
      this.loadIngredientViews(this.recipe.recipeId);
    });
  }
  editIngredient() {
    this.ingredientService
      .update(this.ingredientToAdd)
      .pipe(
        catchError((error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error updating ingredient',
            life: 3000,
          });
          throw error;
        })
      )
      .subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Ingredient updated',
          life: 3000,
        });
        this.loadIngredientViews(this.recipe.recipeId);
        this.displayEditIngredientDialog = false;
      });
  }
  saveRecipe() {
    if (this.recipe.recipeId) {
      this.updateRecipe();
    } else {
      this.createRecipe();
    }
  }
  updateRecipe() {
    this.recipe.recipeCategoryId = this.selectedRecipeCategory.recipeCategoryId;
    this.recipeService
      .update(this.recipe)
      .pipe(
        catchError((error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error saving recipe',
            life: 3000,
          });
          throw error;
        })
      )
      .subscribe((data) => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',

          detail: 'Recipe saved',
          life: 3000,
        });
      });
  }
  createRecipe() {
    this.recipe.recipeId = 0;
    this.recipe.recipeCategoryId = this.selectedRecipeCategory.recipeCategoryId;
    console.log(this.selectedRecipeCategory);
    this.recipeService
      .create(this.recipe)
      .pipe(
        catchError((error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error saving recipe',
            life: 3000,
          });
          throw error;
        })
      )
      .subscribe((data) => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Recipe saved',
          life: 3000,
        });
        this.recipe = data;
      });
  }
  showEditIngredientDialog(item: IngredientDataView) {
    this.displayEditIngredientDialog = true;
    this.ingredientService.getById(item.ingredientId).subscribe((data) => {
      this.ingredientToAdd = data;
    });
  }
  updateIngredient() {
    this.ingredientService
      .update(this.ingredientToAdd)
      .pipe(
        catchError((error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error updating ingredient',
            life: 3000,
          });
          throw error;
        })
      )
      .subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Ingredient updated',
          life: 3000,
        });
        this.loadIngredientViews(this.recipe.recipeId);
        this.recipeService.recalculateMacros(this.recipe.recipeId).subscribe();
        this.displayEditIngredientDialog = false;
      });
  }
  showAddIngredientDialog() {
    this.ingredientToAddDialog = true;
    this.ingredientToAdd = new Ingredient();
  }
  hideIngredientAddDialog() {
    this.ingredientToAddDialog = false;
    this.ingredientToAdd = new Ingredient();
  }
  hideEditIngredientDialog() {
    this.displayEditIngredientDialog = false;
    this.ingredientToAdd = new Ingredient();
  }
  addIngredient() {
    this.ingredientToAdd.recipeId = this.recipe.recipeId;
    this.ingredientToAdd.ingredientId = 0;
    this.ingredientToAdd.baseMaterialId =
      this.selectedMaterialToCreateIngredient.materialId;
    console.log(this.ingredientToAdd);
    this.ingredientService
      .create(this.ingredientToAdd)
      .pipe(
        catchError((error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error adding ingredient',
            life: 3000,
          });
          throw error;
        })
      )
      .subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Ingredient added',
          life: 3000,
        });
        this.recipeService.recalculateMacros(this.recipe.recipeId).subscribe();
        this.loadIngredientViews(this.recipe.recipeId);
        this.ingredientToAddDialog = false;
      });
  }
  loadIngredientViews(recipeId: number) {
    this.ingredientService.getAllByRecipeId(recipeId).subscribe((data) => {
      this.ingredientViews = data;
    });
  }
  loadIngredients(recipeId: number) {
    this.ingredientService.getAllByRecipeId(recipeId).subscribe((data) => {
      this.ingredients = data;
    });
  }
  loadRecipeCategories() {
    this.recipeCategoryService
      .readAll()
      .pipe(
        catchError((error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error loading recipe categories',
          });
          throw error;
        })
      )
      .subscribe((data: RecipeCategory[]) => {
        this.recipeCategories = data;
        if (this.recipe.recipeId) {
          this.selectedRecipeCategory = data.find(
            (t) => t.recipeCategoryId == this.recipe.recipeCategoryId
          );
        }
      });
  }
  loadBaseMaterials() {
    this.baseMaterialService
      .readAll()
      .pipe(
        catchError((error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error loading base materials',
          });
          throw error;
        })
      )
      .subscribe((data) => {
        this.baseMaterials = data;
        this.selectedMaterialToCreateIngredient = this.baseMaterials[0];
      });
  }
  editMaterial(arg0: any) {
    throw new Error('Method not implemented.');
  }
  showMaterialInfo(arg0: any) {
    throw new Error('Method not implemented.');
  }
}
