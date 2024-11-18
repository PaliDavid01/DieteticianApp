import {
  Component,
  Input,
  input,
  OnDestroy,
  OnInit,
  Signal,
} from '@angular/core';
import { BehaviorSubject, Subscription } from 'rxjs';
import {
  DayMenuService,
  GetDayMenuMacroDataResult,
  GetMealMacroDataResult,
  Meal,
  MealService,
} from 'src/app/services/generated-client';

@Component({
  selector: 'app-meal-info-card',
  standalone: false,
  templateUrl: './meal-info-card.component.html',
  styleUrl: './meal-info-card.component.css',
})
export class MealInfoCardComponent implements OnInit, OnDestroy {
  //input signal
  @Input() mealId: number;
  @Input() refreshTrigger: BehaviorSubject<void>;
  meal: Meal;
  mealData: GetMealMacroDataResult;
  refreshSubscription: Subscription;

  constructor(private mealService: MealService) {}
  ngOnDestroy(): void {
    this.refreshSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.loadMealData();
  }

  loadMealData() {
    if (this.mealId > 1) {
      this.mealService.getMealMacroData(this.mealId).subscribe((data) => {
        this.mealData = data;
      });
      this.mealService.getById(this.mealId).subscribe((meal) => {
        this.meal = meal;
      });
    }
  }
}
