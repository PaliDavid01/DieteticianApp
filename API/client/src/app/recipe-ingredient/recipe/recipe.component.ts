import { Component } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Recipe, RecipeService } from 'src/app/services/generated-client';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrl: './recipe.component.css',
})
export class RecipeComponent {
  displayDialog: boolean = false;
  selectedRecipes: any;
  Delete: string = 'Delete';
  recipe: Recipe;
  recipes!: Recipe[];
  constructor(
    private recipeService: RecipeService,
    private messageService: MessageService,
    private router: Router,
    private confirmationService: ConfirmationService
  ) {}
  ngOnInit(): void {
    this.loadRecipes();
  }

  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.recipes);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: 'xlsx',
        type: 'array',
      });
      this.saveAsExcelFile(excelBuffer, 'recipes');
    });
  }

  deleteSelectedRecipes() {
    throw new Error('Method not implemented.');
  }

  hideDialog() {
    this.displayDialog = false;
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE =
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE,
    });
    FileSaver.saveAs(
      data,
      fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION
    );
  }

  loadRecipes() {
    this.recipeService.readAll().subscribe((data) => {
      this.recipes = data;
    });
  }
  deleteRecipe(recipe: Recipe) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + recipe.recipeName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.recipeService.delete(recipe.recipeId).subscribe(
          (data) => {
            this.loadRecipes();
            this.messageService.add({
              severity: 'success',
              summary: 'Successful',
              detail: 'Recipe Deleted',
              life: 3000,
            });
          },
          (error) => {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: 'Error deleting recipe',
              life: 3000,
            });
          }
        );
      },
    });
  }

  editRecipe(item: Recipe) {
    this.router.navigate(['/recipe-edit', item.recipeId]);
  }
  showInfo(item: Recipe) {
    this.recipe = item;
    this.displayDialog = true;
  }
  createRecipe() {
    this.router.navigate(['/recipe-edit', 0]);
  }
}
