import { Component } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-menu-list',
  standalone: false,
  templateUrl: './menu-list.component.html',
  styleUrl: './menu-list.component.css',
})
export class MenuListComponent {
  displayDialog: boolean = false;
  selectedRecipes: any;
  Delete: string = 'Delete';
  item: any;
  items: any[];
  constructor(
    private messageService: MessageService,
    private router: Router,
    private confirmationService: ConfirmationService
  ) {}
  ngOnInit(): void {
    this.load();
  }

  exportExcel() {
    // import('xlsx').then((xlsx) => {
    //   const worksheet = xlsx.utils.json_to_sheet(this.recipes);
    //   const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
    //   const excelBuffer: any = xlsx.write(workbook, {
    //     bookType: 'xlsx',
    //     type: 'array',
    //   });
    //   this.saveAsExcelFile(excelBuffer, 'recipes');
    // });
  }

  deleteSelected() {
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

  load() {
    // this.recipeService.readAll().subscribe((data) => {
    //   this.recipes = data;
    // });
  }
  delete(recipe: any) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + recipe.recipeName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        // this.recipeService.delete(recipe.recipeId).subscribe(
        //   (data) => {
        //     this.loadRecipes();
        //     this.messageService.add({
        //       severity: 'success',
        //       summary: 'Successful',
        //       detail: 'Recipe Deleted',
        //       life: 3000,
        //     });
        //   },
        //   (error) => {
        //     this.messageService.add({
        //       severity: 'error',
        //       summary: 'Error',
        //       detail: 'Error deleting recipe',
        //       life: 3000,
        //     });
        //   }
        // );
      },
    });
  }

  edit(item: any) {
    this.router.navigate(['/recipe-edit', item.recipeId]);
  }
  showInfo(item: any) {
    // this.recipe = item;
    this.displayDialog = true;
  }
  create() {
    this.router.navigate(['/menu-edit', 0]);
  }
}
