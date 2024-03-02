import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Nullable } from 'primeng/ts-helpers';
import { map } from 'rxjs';
import { MaterialGetDTO } from 'src/app/models/DTOs/MaterialDTO';
import { User } from 'src/app/models/user';
import { AccountService } from 'src/app/services/account.service';
import { MaterialService } from 'src/app/services/material.service';

@Component({
  selector: 'app-material-update',
  templateUrl: './material-update.component.html',
  styleUrls: ['./material-update.component.css']
})
export class MaterialUpdateComponent {
  @Input() sMaterial: MaterialGetDTO | any;
  constructor(private materialService: MaterialService, private accountService: AccountService) {
  }

  update(){
    this.accountService.currentUser$.pipe(map((user:User | any) => {
      this.sMaterial.updatedBy = user.firstName +' '+user.lastName
    } ))
    this.sMaterial.updated = new Date().toISOString();
    this.materialService.updateMaterial(this.sMaterial).subscribe(() => console.log("dd"))
  }
}
