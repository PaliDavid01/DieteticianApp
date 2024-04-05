import { Component, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Allergen, AllergenService } from 'src/app/services/generated-client';
import { Table } from 'primeng/table';
import * as FileSaver from 'file-saver';

@Component({
  selector: 'app-allergen',
  standalone: false,
  templateUrl: './allergen.component.html',
  styleUrl: './allergen.component.css',
  providers: [MessageService, ConfirmationService],
})
export class AllergenComponent {
  @ViewChild('dt') dt: Table;

  allergenDialog: boolean = false;

  allergens!: Allergen[];

  allergen!: Allergen;

  selectedAllergens!: Allergen[] | null;

  submitted: boolean = false;

  Delete: string = 'Delete';

  constructor(
    private allergenService: AllergenService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.allergenService.readAll().subscribe((data) => {
      this.allergens = data;
    });
  }
  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.allergens);
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
    this.allergen = new Allergen();
    this.submitted = false;
    this.allergenDialog = true;
  }

  deleteSelectedAllergen() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected products?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {},
    });
  }

  editAllergen(allergen: Allergen) {
    this.allergen = allergen;
    this.allergenDialog = true;
  }

  deleteAllergen(allergen: Allergen) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + allergen.allergenName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.allergenService.delete(allergen.allergenId).subscribe(
          (data) => {
            this.messageService.add({
              severity: 'success',
              summary: 'Successful',
              detail: 'Allergen Deleted',
              life: 3000,
            });
            this.allergens = this.allergens.filter(
              (val) => val.allergenId !== allergen.allergenId
            );
            this.allergenDialog = false;
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
    this.allergenDialog = false;
    this.submitted = false;
  }
  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  saveAllergen() {
    this.submitted = true;
    if (this.allergen.allergenId) {
      this.allergenService.update(this.allergen).subscribe(
        (data) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Allergen Updated',
            life: 3000,
          });
          this.allergens[this.findIndexById(this.allergen.allergenCode)] =
            this.allergen;
          this.allergenDialog = false;
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
      this.allergen.allergenId = 0;
      this.allergenService.create(this.allergen).subscribe(
        (data) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Allergen Created',
            life: 3000,
          });
          this.allergenService.readAll().subscribe((data) => {
            this.allergens = data;
          });
          this.allergenDialog = false;
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

  findIndexById(allergenCode: string): number {
    let index = -1;
    for (let i = 0; i < this.allergens.length; i++) {
      if (this.allergens[i].allergenCode === allergenCode) {
        index = i;
        break;
      }
    }

    return index;
  }
}
