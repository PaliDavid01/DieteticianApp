import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import {
  Allergen,
  AllergenMaterial,
  AllergenMaterialService,
  AllergenService,
  BaseMaterial,
  BaseMaterialService,
  MaterialGroup,
  MaterialGroupService,
  UpdateAllergenMaterialsDTO,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-material-create',
  templateUrl: './material-create.component.html',
  styleUrls: ['./material-create.component.css'],
  providers: [
    BaseMaterialService,
    MaterialGroupService,
    AllergenMaterialService,
  ],
})
export class MaterialCreateComponent implements OnInit {
  displayDialog: boolean = true;
  materialGroups: MaterialGroup[] = [];
  selectedAllergens: Allergen[] = [];
  allergens: Allergen[] = [];
  material: BaseMaterial;
  submitted: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private baseMaterialService: BaseMaterialService,
    private materialGroupService: MaterialGroupService,
    private messageService: MessageService,
    private allergenMaterialService: AllergenMaterialService,
    private allergenService: AllergenService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.material = data['material'];
    });
    this.materialGroupService.readAll().subscribe((data) => {
      this.materialGroups = data;
    });
    this.allergenService.readAll().subscribe((data) => {
      this.allergens = data;
    });
    if (this.material.materialId) {
      console.log(this.material.materialId);
      this.allergenMaterialService
        .getAllergensByMaterialId(this.material.materialId)
        .subscribe((data) => {
          this.selectedAllergens = this.allergens.filter((allergen) =>
            data.some(
              (allergenMaterial) =>
                allergenMaterial.allergenCode === allergen.allergenCode
            )
          );
        });
    }
  }

  saveMaterial() {
    let updateAllergenMaterialsDTO: UpdateAllergenMaterialsDTO;
    let allergens: AllergenMaterial[] = [];
    if (this.material.materialId) {
      allergens = this.selectedAllergens.map((allergen) => {
        return new AllergenMaterial({
          allergenMaterialId: 0,
          allergenId: allergen.allergenId,
          materialId: this.material.materialId,
        });
      });
      updateAllergenMaterialsDTO = new UpdateAllergenMaterialsDTO({
        materialId: this.material.materialId,
        allergenMaterials: allergens,
      });
      this.baseMaterialService.update(this.material).subscribe(
        (data) => {
          this.allergenMaterialService
            .updateAllergenMaterials(updateAllergenMaterialsDTO)
            .subscribe();
          this.router.navigate(['/material']);
        },
        (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: error.error,
            life: 3000,
          });
        }
      );
    } else {
      this.material.materialId = 0;
      this.baseMaterialService.create(this.material).subscribe(
        (data) => {
          if (allergens.length > 0) {
          }
          this.router.navigate(['/material']);
        },
        (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: error.error,
            life: 3000,
          });
        }
      );
    }
  }
}
