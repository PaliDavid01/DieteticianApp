import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { Table } from 'primeng/table';
import {
  AgeCategory,
  AgeCategoryService,
  Allergen,
  AllergenCustomer,
  AllergenCustomerService,
  AllergenService,
  Customer,
  CustomerListView,
  CustomerService,
  UpdateAllergenCustomersDTO,
} from 'src/app/services/generated-client';
import { OrderEditModalComponent } from '../order-edit-modal/order-edit-modal.component';

@Component({
  selector: 'app-customer-list',
  standalone: false,
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css',
})
export class CustomerListComponent {
  @ViewChild('dt') dt: Table;

  showCustomerDialog: boolean = false;

  customers!: CustomerListView[];

  selectedCustomers!: CustomerListView[] | null;

  submitted: boolean = false;

  Delete: string = 'Delete';
  // Create / update data
  customer!: Customer;
  selectedAgeCategory!: AgeCategory | null;
  selectedAllegens!: Allergen[] | null;
  selectedAllergenCustomers: number[] = [];
  allergens!: Allergen[];
  ageCategories!: AgeCategory[];

  constructor(
    private customerService: CustomerService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private agecategoryService: AgeCategoryService,
    private allergenService: AllergenService,
    private allergenCustomerService: AllergenCustomerService,
    private router: Router,
    private dialogService: DialogService
  ) {}

  ngOnInit() {
    this.loadCustomers();
    this.loadAgeCategories();
    this.loadAllergens();
  }

  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(this.customers);
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
    this.customer = new Customer();
    this.showCustomerDialog = true;
  }

  editCustomer(customerListView: CustomerListView) {
    if (customerListView.customerId) {
      this.customerService
        .getById(customerListView.customerId)
        .subscribe((data) => {
          this.customer = data;
        });
      this.allergenCustomerService
        .getAllergensByCustomerId(customerListView.customerId)
        .subscribe((data) => {
          this.selectedAllergenCustomers = data;
          this.selectedAllegens = this.allergens.filter((allergen) =>
            data.some(
              (allergenCustomer) => allergenCustomer === allergen.allergenId
            )
          );
        });
    }

    this.selectedAgeCategory = this.ageCategories.find(
      (ageCategory) =>
        ageCategory.ageCategoryId === customerListView.ageCategoryId
    );
    this.showCustomerDialog = true;
  }

  editOrder(customerListView: CustomerListView) {
    this.dialogService.open(OrderEditModalComponent, {
      data: {
        customerId: customerListView.customerId,
      },
      header: 'Edit Orders',
      width: '70%',
      height: '80%',
    });
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  saveCustomer() {
    this.submitted = true;
    this.customer.hasAllergies = this.selectedAllegens.length > 0;
    this.customer.ageCategoryId = this.selectedAgeCategory.ageCategoryId;
    if (this.customer.customerId) {
      this.customerService.update(this.customer).subscribe(
        (data) => {
          if (this.selectedAllegens.length > 0) {
            let allergenCustomerUpdateDTO = {
              allergenCustomers: this.selectedAllegens.map((allergen) => {
                return {
                  allergenId: allergen.allergenId,
                  customerId: this.customer.customerId,
                } as AllergenCustomer;
              }),
              customerId: this.customer.customerId,
            } as UpdateAllergenCustomersDTO;
            this.allergenCustomerService
              .updateAllergenMaterials(allergenCustomerUpdateDTO)
              .subscribe();
          }
          this.showCustomerDialog = false;
          this.loadCustomers();
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
      this.customer.customerId = 0;
      this.customerService.create(this.customer).subscribe(
        (data) => {
          if (this.selectedAllegens.length > 0) {
            let allergenCustomerUpdateDTO = {
              allergenCustomers: this.selectedAllegens.map((allergen) => {
                return {
                  allergenId: allergen.allergenId,
                  customerId: data.customerId,
                } as AllergenCustomer;
              }),
              customerId: data.customerId,
            } as UpdateAllergenCustomersDTO;
            this.allergenCustomerService
              .updateAllergenMaterials(allergenCustomerUpdateDTO)
              .subscribe();
          }
          this.showCustomerDialog = false;
          this.loadCustomers();
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

  findIndexById(customerId: number): number {
    let index = -1;
    for (let i = 0; i < this.customers.length; i++) {
      if (this.customers[i].customerId == customerId) {
        index = i;
        break;
      }
    }

    return index;
  }

  loadCustomers() {
    this.customerService.getAllCustomerListView().subscribe((data) => {
      this.customers = data;
      console.log(this.customers);
    });
  }

  loadAgeCategories() {
    this.agecategoryService.readAll().subscribe((data) => {
      this.ageCategories = data;
    });
  }

  loadAllergens() {
    this.allergenService.readAll().subscribe((data) => {
      this.allergens = data;
    });
  }

  hideDialog() {
    this.showCustomerDialog = false;
  }
}
