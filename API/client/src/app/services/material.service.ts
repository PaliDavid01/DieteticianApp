import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { MaterialGetDTO } from '../models/DTOs/MaterialDTO';
import { map } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MaterialService implements OnInit {
  baseUrl = environment.apiUrl;
  materials: MaterialGetDTO[]  = []
  
  constructor(private http: HttpClient) { }
  ngOnInit(): void {
    
  }

  getMaterials(){
    return this.http.get<MaterialGetDTO[]>(this.baseUrl+'Material/GetAll').pipe(
      map(materials =>{
        this.materials = materials;
        return this.materials;
      })
      
    )
  }
  deleteMaterial(id: string){
    return this.http.delete(this.baseUrl + 'Material?id='+ id);
  }
  updateMaterial(item: MaterialGetDTO){
    return this.http.put(this.baseUrl+ 'Material/',  item)
  }
}
