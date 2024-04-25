import { Component, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import {
  RecipeCategory,
  RecipeCategoryService,
} from 'src/app/services/generated-client';
import { Table } from 'primeng/table';
import * as FileSaver from 'file-saver';

@Component({
  selector: 'app-recipe-category',
  templateUrl: './recipe-category.component.html',
  styleUrl: './recipe-category.component.css',
})
export class RecipeCategoryComponent {
  @ViewChild('dt') dt: Table;

  recipeCategoryDialog: boolean = false;

  recipeCategories!: RecipeCategory[];

  recipeCategory!: RecipeCategory;

  selectedrecipeCategories!: RecipeCategory[] | null;

  submitted: boolean = false;

  Delete: string = 'Delete';

  constructor(
    private recipeCategoryService: RecipeCategoryService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.recipeCategoryService.readAll().subscribe((data) => {
      this.recipeCategories = data;
    });
  }
  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.recipeCategories);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: 'xlsx',
        type: 'array',
      });
      this.saveAsExcelFile(excelBuffer, 'recipeCategories');
    });
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

  openNew() {
    this.recipeCategory = new RecipeCategory();
    this.submitted = false;
    this.recipeCategoryDialog = true;
  }

  deleteSelectedRecipeCategory() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected products?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {},
    });
  }

  editRecipeCategory(recipeCategory: RecipeCategory) {
    this.recipeCategory = recipeCategory;
    this.recipeCategoryDialog = true;
  }

  deleteRecipeCategory(recipeCategory: RecipeCategory) {
    this.confirmationService.confirm({
      message:
        'Are you sure you want to delete ' + recipeCategory.categoryName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.recipeCategoryService
          .delete(recipeCategory.recipeCategoryId)
          .subscribe(
            (data) => {
              this.messageService.add({
                severity: 'success',
                summary: 'Successful',
                detail: 'Recipe ategory Deleted',
                life: 3000,
              });
              this.recipeCategories = this.recipeCategories.filter(
                (val) =>
                  val.recipeCategoryId !== recipeCategory.recipeCategoryId
              );
              this.recipeCategoryDialog = false;
            },
            (error) => {
              this.messageService.add({
                severity: 'error',
                summary: 'Error',
                detail: 'Recipe category not Deleted',
                life: 3000,
              });
            }
          );
      },
    });
  }

  hideDialog() {
    this.recipeCategoryDialog = false;
    this.submitted = false;
  }
  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  saveRecipeCategoryn() {
    this.submitted = true;
    if (this.recipeCategory.recipeCategoryId) {
      this.recipeCategoryService.update(this.recipeCategory).subscribe(
        (data) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Recipe category Updated',
            life: 3000,
          });
          this.recipeCategories[
            this.findIndexById(this.recipeCategory.recipeCategoryId)
          ] = this.recipeCategory;
          this.recipeCategoryDialog = false;
        },
        (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Recipe category update failed',
            life: 3000,
          });
        }
      );
    } else {
      this.recipeCategory.recipeCategoryId = 0;
      this.recipeCategoryService.create(this.recipeCategory).subscribe(
        (data) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Recipe category Created',
            life: 3000,
          });
          this.recipeCategoryService.readAll().subscribe((data) => {
            this.recipeCategories = data;
          });
          this.recipeCategoryDialog = false;
        },
        (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Recipe category creation failed',
            life: 3000,
          });
        }
      );
    }
  }

  findIndexById(recipeCategoryId: number): number {
    let index = -1;
    for (let i = 0; i < this.recipeCategories.length; i++) {
      if (this.recipeCategories[i].recipeCategoryId === recipeCategoryId) {
        index = i;
        break;
      }
    }

    return index;
  }
}
