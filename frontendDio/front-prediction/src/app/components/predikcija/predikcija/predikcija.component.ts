import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { range } from 'rxjs';
import { HouseElements } from 'src/app/interfaces/houseElements';
import { SimpleRestService } from 'src/app/services/simplerest.service';

@Component({
  selector: 'app-predikcija',
  templateUrl: './predikcija.component.html',
  styleUrls: ['./predikcija.component.scss']
})
export class PredikcijaComponent implements OnInit {
 public predictionForm !: FormGroup;
 public houseValue : number = 0;
 public viewNumbers : number[] = [0,1,2,3,4];
 public conditionNumbers : number[] = [1,2,3,4,5];
 public gradeNumbers : number[] = [1,2,3,4,5,6,7,8,9,10,11,12,13];
 public house!: HouseElements;

  constructor(protected smtp: SimpleRestService, public fb:FormBuilder) { }

  ngOnInit(): void {
    this.predictionForm = this.fb.group({
      bedrooms : [0, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      bathrooms : ["0", [Validators.required, Validators.min(0), Validators.pattern("^([\d]{0,5})(\.[\d]{1,2})?$")]],
      sqftLiving : [0, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      sqftLot : [0, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      floors : ["0", [Validators.required, Validators.min(0), Validators.pattern("^([\d]{0,5})(\.[\d]{1,2})?$")]],
      view : [this.viewNumbers[0]],
      condition : [this.conditionNumbers[0]],
      grade : [this.gradeNumbers[0]],
      yearBuilt : [1800, [Validators.required, Validators.min(1800), Validators.max(<number>new Date().getFullYear()),Validators.pattern("^[0-9]*$")]],
      yearRenovated : [0,[Validators.required, ,Validators.max(<number>new Date().getFullYear()),Validators.pattern("^[0-9]*$"), this.yearRenovatedIsGreaterThanBuilt('yearBuilt', 'yearRenovated')]],
      sqftAbove : [0, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      sqftBasement : [0, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]]
    });
  }

  public onSendDataToApi() : void {
    this.houseValue = 0;
    this.house = {
      bedrooms : this.predictionForm.value.bedrooms * 1,
      bathrooms: this.predictionForm.value.bathrooms,
      sqftLiving: this.predictionForm.value.sqftLiving * 1,
      sqftLot: this.predictionForm.value.sqftLot * 1,
      floors: this.predictionForm.value.floors,
      view : this.predictionForm.value.view * 1,
      condition : <number>this.predictionForm.value.condition * 1,
      yearBuilt:<number> this.predictionForm.value.yearBuilt * 1,
      yearRenovated: <number>this.predictionForm.value.yearRenovated * 1,
      grade: <number>this.predictionForm.value.grade * 1,
      sqftAbove: <number>this.predictionForm.value.sqftAbove * 1,
      sqftBasement: <number>this.predictionForm.value.sqftBasement * 1
    }
    this.smtp.postPredictionValue(this.house).subscribe(
      (response) => {
        this.houseValue = response | 0;
      },
      (error) => {
        console.error('Request failed with error : '+ error);
      }
    );
  }

   private yearRenovatedIsGreaterThanBuilt (yearBuilt: string, yearRenovated: string) : ValidatorFn{
    return (control : AbstractControl) : ValidationErrors | null => {
      let formGroup = control as FormGroup;

      let valueOfBuiltYear = formGroup.get(yearBuilt)?.value;
      let valueOfRenovatedYear = formGroup.get(yearRenovated)?.value;

      if((valueOfBuiltYear <= valueOfRenovatedYear) || valueOfRenovatedYear === 0 ) return null;
      else {
        return {wrongValue : true}
      }
    }
};

}
