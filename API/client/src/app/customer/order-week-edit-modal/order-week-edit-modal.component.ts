import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import {
  OrderWeekMenu,
  OrderWeekMenuService,
  WeekMenu,
  WeekMenuService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-order-week-edit-modal',
  standalone: false,
  templateUrl: './order-week-edit-modal.component.html',
  styleUrl: './order-week-edit-modal.component.css',
})
export class OrderWeekEditModalComponent implements OnInit {
  orderId: number = 0;
  customerId: number = 0;
  weekMenus: WeekMenu[] = [];
  constructor(
    public ref: DynamicDialogRef,
    public dialogConfig: DynamicDialogConfig,
    private orderWeekMenuService: OrderWeekMenuService,
    private weekMenuService: WeekMenuService,
    private messageService: MessageService
  ) {}
  ngOnInit(): void {
    this.orderId = this.dialogConfig.data.orderId;
    this.customerId = this.dialogConfig.data.customerId;
    this.weekMenuService
      .readAllByCustomerPreferences(this.customerId)
      .subscribe((weekMenus) => {
        this.weekMenus = weekMenus;
        console.log(weekMenus);
      });
  }

  addWeekMenu(weekMenuId: number) {
    let orderWeekMenu = {
      orderWeekMenuId: 0,
      orderId: this.orderId,
      weekMenuId: weekMenuId,
    } as OrderWeekMenu;
    this.orderWeekMenuService.create(orderWeekMenu).subscribe(() => {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Week menu added',
      });
    });
    this.ref.close();
  }
}
