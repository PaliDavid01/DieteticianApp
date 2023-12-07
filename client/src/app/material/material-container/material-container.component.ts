import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Nullable } from 'primeng/ts-helpers';
import { Observable, map } from 'rxjs';
import { MaterialGetDTO } from 'src/app/models/DTOs/MaterialDTO';
import { MaterialService } from 'src/app/services/material.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-material-container',
  templateUrl: './material-container.component.html',
  styleUrls: ['./material-container.component.css']
})
export class MaterialContainerComponent implements OnInit {
  materials$: Observable<MaterialGetDTO[]> | undefined;
  baseUrl = environment.apiUrl;
  objectNames: String[] | any;
  selectedMaterial: MaterialGetDTO | Nullable;

  constructor(private materialService: MaterialService) {}
  ngOnInit(): void {
    this.materials$ = this.materialService.getMaterials();
  }
  delete(id:string){
    this.materialService.deleteMaterial(id).subscribe(() => console.log(id))
  }
  update(item: MaterialGetDTO){
    this.selectedMaterial = item; 
  }

  

  
}
