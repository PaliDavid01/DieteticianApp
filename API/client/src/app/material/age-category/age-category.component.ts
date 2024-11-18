import { Component, OnInit, ViewChild } from '@angular/core';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import {
  AgeCategory,
  AgeCategoryService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-age-category',
  standalone: false,
  templateUrl: './age-category.component.html',
  styleUrl: './age-category.component.css',
})
export class AgeCategoryComponent implements OnInit {
  @ViewChild('dt') dt: Table;

  ageCategoryDialog: boolean = false;

  ageCategories!: AgeCategory[];

  ageCategory!: AgeCategory;

  selectedAgeCategories!: AgeCategory[] | null;

  submitted: boolean = false;

  Delete: string = 'Delete';

  constructor(
    private agecategoryService: AgeCategoryService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadAllergens();
  }

  loadAllergens() {
    this.agecategoryService.readAll().subscribe((data) => {
      this.ageCategories = data;
    });
  }

  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.ageCategories);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: 'xlsx',
        type: 'array',
      });
      this.saveAsExcelFile(excelBuffer, 'allergens');
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
    this.ageCategory = new AgeCategory();
    this.submitted = false;
    this.ageCategoryDialog = true;
  }

  deleteSelectedAgeCategory() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected products?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {},
    });
  }

  editAgeCategory(ageCategory: AgeCategory) {
    this.ageCategory = ageCategory;
    this.ageCategoryDialog = true;
  }

  deleteAgeCategory(ageCategory: AgeCategory) {
    this.confirmationService.confirm({
      message:
        'Are you sure you want to delete ' + ageCategory.ageCategoryName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.agecategoryService.delete(ageCategory.ageCategoryId).subscribe(
          (data) => {
            this.messageService.add({
              severity: 'success',
              summary: 'Successful',
              detail: 'Allergen Deleted',
              life: 3000,
            });
            this.loadAllergens();
            this.ageCategoryDialog = false;
          },
          (error) => {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: 'Allergen not Deleted',
              life: 3000,
            });
          }
        );
      },
    });
  }

  hideDialog() {
    this.ageCategoryDialog = false;
    this.submitted = false;
  }
  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  saveAgeCategory() {
    this.submitted = true;
    if (this.ageCategory.ageCategoryId) {
      this.agecategoryService.update(this.ageCategory).subscribe(
        (data) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Allergen Updated',
            life: 3000,
          });
          this.loadAllergens();
          this.ageCategoryDialog = false;
        },
        (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Allergen update failed',
            life: 3000,
          });
        }
      );
    } else {
      this.ageCategory.ageCategoryId = 0;
      this.agecategoryService.create(this.ageCategory).subscribe(
        (data) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Allergen Created',
            life: 3000,
          });
          this.loadAllergens();
          this.ageCategoryDialog = false;
        },
        (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'Allergen creation failed',
            life: 3000,
          });
        }
      );
    }
  }

  findIndexById(ageCategoryId: number): number {
    let index = -1;
    for (let i = 0; i < this.ageCategories.length; i++) {
      if (this.ageCategories[i].ageCategoryId == ageCategoryId) {
        index = i;
        break;
      }
    }

    return index;
  }
}
