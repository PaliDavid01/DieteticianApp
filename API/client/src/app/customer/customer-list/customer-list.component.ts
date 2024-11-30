import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { ConfirmationService, MessageService } from 'primeng/api';
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
    private router: Router
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
      this.allergenCustomerService
        .getAllergensByCustomerId(this.customer.customerId)
        .subscribe((data) => {
          this.selectedAllergenCustomers = data;
          this.selectedAllegens = this.allergens.filter((allergen) =>
            data.some(
              (allergenCustomer) => allergenCustomer === allergen.allergenId
            )
          );
        });
    }
    this.customerService
      .getById(customerListView.customerId)
      .subscribe((data) => {
        this.customer = data;
      });
    this.selectedAgeCategory = this.ageCategories.find(
      (ageCategory) => ageCategory.ageCategoryId === this.customer.ageCategoryId
    );
    this.showCustomerDialog = true;
  }

  deleteCustomer(customerListView: CustomerListView) {
    this.confirmationService.confirm({
      message:
        'Are you sure you want to delete ' +
        customerListView.customerName +
        '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.customerService.delete(customerListView.customerId).subscribe(
          (data) => {
            this.messageService.add({
              severity: 'success',
              summary: 'Successful',
              detail: 'Allergen Deleted',
              life: 3000,
            });
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
    this.loadCustomers();
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
