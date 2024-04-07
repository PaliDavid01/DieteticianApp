import { Component, OnInit, ViewChild } from '@angular/core';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import {
  BaseMaterial,
  BaseMaterialService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-material-container',
  templateUrl: './material-container.component.html',
  styleUrls: ['./material-container.component.css'],
})
export class MaterialContainerComponent implements OnInit {
  @ViewChild('dt') dt: Table | undefined;

  materialDialog: boolean = false;

  materials!: BaseMaterial[];

  material!: BaseMaterial;

  selectedMaterials!: BaseMaterial[] | null;

  submitted: boolean = false;

  statuses!: any[];
  Delete: string = 'Delete';

  constructor(
    private materialService: BaseMaterialService,
    private messageService: MessageService,
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

  openNew() {
    this.material = new BaseMaterial();
    this.submitted = false;
    this.materialDialog = true;
  }

  deleteSelectedMaterial() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected products?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.materials = this.materials.filter(
          (val) => !this.selectedMaterials?.includes(val)
        );
        this.selectedMaterials = null;
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Products Deleted',
          life: 3000,
        });
      },
    });
  }

  editMaterial(allergen: BaseMaterial) {
    this.material = allergen;
    this.materialDialog = true;
  }

  deleteMaterial(material: BaseMaterial) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + material.materialName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
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
    });
  }

  hideDialog() {
    this.materialDialog = false;
    this.submitted = false;
  }
  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  saveMaterial() {
    this.submitted = true;

    if (this.material.materialName?.trim()) {
      if (this.material.materialId) {
        this.materials[this.findIndexById(this.material.materialId)] =
          this.material;
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Allergen Updated',
          life: 3000,
        });
      } else {
        this.material.materialId = 11;
        this.materials.push(this.material);
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Allergen Created',
          life: 3000,
        });
      }

      this.materials = [...this.materials];
      this.materialDialog = false;
      this.material = new BaseMaterial();
    }
  }

  findIndexById(materialId: number): number {
    let index = -1;
    for (let i = 0; i < this.materials.length; i++) {
      if (this.materials[i].materialId === materialId) {
        index = i;
        break;
      }
    }

    return index;
  }

  createId(): string {
    let id = '';
    var chars =
      'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }
}
