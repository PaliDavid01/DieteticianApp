import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import {
  DialogService,
  DynamicDialogConfig,
  DynamicDialogRef,
} from 'primeng/dynamicdialog';
import {
  Order,
  OrderListView,
  OrderService,
  OrderWeekMenuService,
} from 'src/app/services/generated-client';
import { OrderWeekEditModalComponent } from '../order-week-edit-modal/order-week-edit-modal.component';

@Component({
  selector: 'app-order-edit-modal',
  standalone: false,
  templateUrl: './order-edit-modal.component.html',
  styleUrl: './order-edit-modal.component.css',
})
export class OrderEditModalComponent implements OnInit {
  orders: OrderListView[] = [];
  customerId: number = 0;
  constructor(
    public ref: DynamicDialogRef,
    public dialogConfig: DynamicDialogConfig,
    private orderService: OrderService,
    private messageService: MessageService,
    private dialogService: DialogService,
    private orderWeekMenuService: OrderWeekMenuService
  ) {}

  ngOnInit(): void {
    this.customerId = this.dialogConfig.data.customerId;
    this.orderService
      .readAllByCustomerId(this.customerId)
      .subscribe((orders) => {
        this.orders = orders;
        if (orders.length == 0) {
          this.orderService
            .initializeOrders(this.customerId)
            .subscribe((order) => {
              this.orderService
                .readAllByCustomerId(this.customerId)
                .subscribe((orders) => {
                  this.orders = orders;
                });
            });
        }
      });
  }

  editWeekOrder(orderId: number) {
    this.dialogService.open(OrderWeekEditModalComponent, {
      data: {
        orderId: orderId,
        customerId: this.customerId,
      },
      header: 'Edit order',
      width: '70%',
    });
    this.orderService
      .readAllByCustomerId(this.customerId)
      .subscribe((orders) => {
        this.orders = orders;
      });
  }

  deleteWeekOrder(orderId: number) {
    this.orderWeekMenuService.deleteByOrderId(orderId).subscribe(() => {
      this.orderService.delete(orderId).subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Order deleted',
        });
        this.orderService
          .readAllByCustomerId(this.customerId)
          .subscribe((orders) => {
            this.orders = orders;
          });
      });
    });
  }
}
