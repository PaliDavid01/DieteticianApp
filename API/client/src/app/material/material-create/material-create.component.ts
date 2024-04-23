import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';
import {
  BaseMaterial,
  BaseMaterialService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-material-create',
  templateUrl: './material-create.component.html',
  styleUrls: ['./material-create.component.css'],
})
export class MaterialCreateComponent implements OnInit {
  displayDialog: boolean = true;
  saveMaterial() {
    console.log(this.material);
  }
  material: BaseMaterial;
  submitted: boolean;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private baseMaterialService: BaseMaterialService
  ) {}
  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.material = data['material'];
    });
  }
}
