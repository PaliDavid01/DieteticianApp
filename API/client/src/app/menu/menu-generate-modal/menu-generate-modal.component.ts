import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import {
  AgeCategory,
  AgeCategoryService,
  Allergen,
  AllergenService,
  UpdateAllergenWeekMenuDataDTO,
  WeekMenuGenerateDataAllergen,
  WeekMenuGenerateDataAllergenService,
  WeekMenuGenerateDataService,
  WeekMenuGenerateDatum,
} from 'src/app/services/generated-client';
interface WeekMenuGenerateDataDTO {
  ageCategoryId: number;
  allergens: number[];
}
@Component({
  selector: 'app-menu-generate-modal',
  standalone: false,
  templateUrl: './menu-generate-modal.component.html',
  styleUrl: './menu-generate-modal.component.css',
})
export class MenuGenerateModalComponent implements OnInit {
  weekMenuId: number;
  weekMenuGenerateData: WeekMenuGenerateDatum = new WeekMenuGenerateDatum();
  weekmenuGenerateDataAllergens: WeekMenuGenerateDataAllergen[] = [];
  ageCategories: AgeCategory[] = [];
  selectedAgeCategory: AgeCategory = new AgeCategory();
  allergens: Allergen[] = [];
  selectedAllergens: Allergen[] = [];
  constructor(
    public ref: DynamicDialogRef,
    public dialogConfig: DynamicDialogConfig,
    public weekMenuGenerateDataService: WeekMenuGenerateDataService,
    public weelMenuGenerateDataAllergenService: WeekMenuGenerateDataAllergenService,
    public allergenService: AllergenService,
    public agecategoryService: AgeCategoryService
  ) {}

  ngOnInit(): void {
    this.weekMenuId = this.dialogConfig.data.weekMenuId;
    this.agecategoryService.readAll().subscribe((data) => {
      if (data) {
        this.ageCategories = data;
      }
    });
    this.allergenService.readAll().subscribe((data) => {
      this.allergens = data;
    });
    this.weekMenuId = this.dialogConfig.data.weekMenuId;
    if (this.weekMenuId > 0) {
      this.loadData();
    }
  }

  loadData() {
    this.weekMenuGenerateDataService
      .getByWeekMenuId(this.weekMenuId)
      .subscribe((data) => {
        if (data) {
          this.weekMenuGenerateData = data;
          this.selectedAgeCategory = this.ageCategories.find(
            (ageCategory) =>
              ageCategory.ageCategoryId ===
              this.weekMenuGenerateData.ageCategoryId
          );
        }
      });
    this.weelMenuGenerateDataAllergenService
      .getByWeekMenuGenerateDataId(this.weekMenuId)
      .subscribe((data) => {
        if (data) {
          this.selectedAllergens = this.allergens.filter((allergen) =>
            data.some(
              (allergenMaterial) =>
                allergenMaterial.allergenId === allergen.allergenId
            )
          );
        }
      });
  }
  save() {
    this.weekMenuGenerateData.ageCategoryId =
      this.selectedAgeCategory.ageCategoryId;
    if (this.weekMenuGenerateData.weekMenuGenerateDataId) {
      let updateAllergenMaterialsDTO: UpdateAllergenWeekMenuDataDTO;
      let allergens: WeekMenuGenerateDataAllergen[] = [];
      allergens = this.selectedAllergens.map((allergen) => {
        return new WeekMenuGenerateDataAllergen({
          weekMenuGenerateDataAllergenId: 0,
          allergenId: allergen.allergenId,
          weekMenuGenerateDataId:
            this.weekMenuGenerateData.weekMenuGenerateDataId,
        });
      });
      updateAllergenMaterialsDTO = new UpdateAllergenWeekMenuDataDTO({
        weekMWeekMenuGenerateDataId:
          this.weekMenuGenerateData.weekMenuGenerateDataId,
        allergenWeekMenuDatas: allergens,
      });
      this.weekMenuGenerateData.ageCategoryId =
        this.selectedAgeCategory.ageCategoryId;
      this.weekMenuGenerateDataService
        .update(this.weekMenuGenerateData)
        .subscribe((data) => {
          if (updateAllergenMaterialsDTO.allergenWeekMenuDatas.length > 0) {
            this.weelMenuGenerateDataAllergenService
              .updateAllergenWeekMenuGenerateDatas(updateAllergenMaterialsDTO)
              .subscribe((data) => {
                let returnableData: WeekMenuGenerateDataDTO = {
                  ageCategoryId: this.selectedAgeCategory.ageCategoryId,
                  allergens: this.selectedAllergens.map(
                    (allergen) => allergen.allergenId
                  ),
                };
                this.ref.close(returnableData);
              });
          }
          let returnableData: WeekMenuGenerateDataDTO = {
            ageCategoryId: this.selectedAgeCategory.ageCategoryId,
            allergens: this.selectedAllergens.map(
              (allergen) => allergen.allergenId
            ),
          };
          this.ref.close(returnableData);
        });
    } else {
      this.weekMenuGenerateData.weekMenuId = this.weekMenuId;
      this.weekMenuGenerateData.weekMenuGenerateDataId = 0;
      this.weekMenuGenerateData.ageCategoryId =
        this.selectedAgeCategory.ageCategoryId;
      this.weekMenuGenerateDataService
        .create(this.weekMenuGenerateData)
        .subscribe((data) => {
          this.weekMenuGenerateData = data;
          let allergens: WeekMenuGenerateDataAllergen[] = [];
          allergens = this.selectedAllergens.map((allergen) => {
            return new WeekMenuGenerateDataAllergen({
              weekMenuGenerateDataAllergenId: 0,
              allergenId: allergen.allergenId,
              weekMenuGenerateDataId:
                this.weekMenuGenerateData.weekMenuGenerateDataId,
            });
          });
          let updateAllergenMaterialsDTO = new UpdateAllergenWeekMenuDataDTO({
            weekMWeekMenuGenerateDataId:
              this.weekMenuGenerateData.weekMenuGenerateDataId,
            allergenWeekMenuDatas: allergens,
          });
          if (updateAllergenMaterialsDTO.allergenWeekMenuDatas.length > 0) {
            this.weelMenuGenerateDataAllergenService
              .updateAllergenWeekMenuGenerateDatas(updateAllergenMaterialsDTO)
              .subscribe(() => {
                let returnableData: WeekMenuGenerateDataDTO = {
                  ageCategoryId: this.selectedAgeCategory.ageCategoryId,
                  allergens: this.selectedAllergens.map(
                    (allergen) => allergen.allergenId
                  ),
                };
                this.ref.close(returnableData);
              });
          }
          let returnableData: WeekMenuGenerateDataDTO = {
            ageCategoryId: this.selectedAgeCategory.ageCategoryId,
            allergens: this.selectedAllergens.map(
              (allergen) => allergen.allergenId
            ),
          };
          this.ref.close(returnableData);
        });
    }
  }
  hideDialog() {
    this.ref.close();
  }
}
