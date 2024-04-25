import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import {
  BaseMaterial,
  BaseMaterialService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-material-container',
  standalone: false,
  templateUrl: './material-container.component.html',
  styleUrls: ['./material-container.component.css'],
  providers: [MessageService, ConfirmationService],
})
export class MaterialContainerComponent {
  @ViewChild('dt') dt: Table;

  materials!: BaseMaterial[];

  material!: BaseMaterial;

  selectedMaterials!: BaseMaterial[] | null;

  statuses!: any[];
  Delete: string = 'Delete';
  displayDialog: boolean = false;

  constructor(
    private materialService: BaseMaterialService,
    private messageService: MessageService,

    private router: Router,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.materialService.getBaseMaterialsExtended().subscribe((data) => {
      this.materials = data;
    });
  }
  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.materials);
      const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: 'xlsx',
        type: 'array',
      });
      this.saveAsExcelFile(excelBuffer, 'materials');
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

  showInfo(material: BaseMaterial) {
    this.material = material;
    this.displayDialog = true;
  }

  deleteSelectedMaterial() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected materials?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {},
    });
  }

  editMaterial(allergen: BaseMaterial) {
    this.router.navigate(['/material-edit', allergen.materialId]);
  }

  createMaterial() {
    this.router.navigate(['/material-edit', 0]);
  }

  deleteMaterial(material: BaseMaterial) {
    console.log(material);
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + material.materialName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.materialService.deleteWithAlllergenMaterials(material).subscribe(
          (data) => {
            this.materials = this.materials.filter(
              (val) => val.materialId !== material.materialId
            );
            this.material = new BaseMaterial();
            this.messageService.add({
              severity: 'success',
              summary: 'Successful',
              detail: 'Product Deleted',
              life: 3000,
            });
          },
          (error) => {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: 'Error deleting product',
            });
          }
        );
      },
    });
  }

  hideDialog() {
    this.displayDialog = false;
  }
  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
