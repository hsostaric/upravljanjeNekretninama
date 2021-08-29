import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { House } from 'src/app/interfaces/house';
import { SimpleRestService } from 'src/app/services/simplerest.service';

@Component({
  selector: 'app-addorupdatehouse',
  templateUrl: './addorupdatehouse.component.html',
  styleUrls: ['./addorupdatehouse.component.scss']
})
export class AddorupdatehouseComponent implements OnInit {

  public houseForm !: FormGroup;
  public houseValue : number = 0;
  public viewNumbers : number[] = [0,1,2,3,4];
  public conditionNumbers : number[] = [1,2,3,4,5];
  public gradeNumbers : number[] = [1,2,3,4,5,6,7,8,9,10,11,12,13];
  public houseModel !: House ;
  public id !: number;
  public isAddMode: boolean = true;

  public buttonText : string = "";

  constructor(protected smtp: SimpleRestService, public fb:FormBuilder, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.inicijalizirajPodatkeZaUnos();
    this.inicijalizirajFormu();
    this.odrediNacinRada();
    if(this.isAddMode){
      this.buttonText = "Dodaj novi zapis.";
    }else {
      this.buttonText ="Uredi zapis";
      this.dohvatiZapisZaEdit();
    }
  }


  private inicijalizirajFormu() {
    this.houseForm = this.fb.group({
      price: [this.houseModel.price, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      bedrooms: [this.houseModel.bedrooms, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      bathrooms: [this.houseModel.bathrooms, [Validators.required, Validators.min(0), Validators.pattern("^([\d]{0,5})(\.[\d]{1,2})?$")]],
      sqftLiving: [this.houseModel.sqftLiving, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      sqftLot: [this.houseModel.sqftLot, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      floors: [this.houseModel.floors, [Validators.required, Validators.min(0), Validators.pattern("^([\d]{0,5})(\.[\d]{1,2})?$")]],
      view: [this.houseModel.view],
      condition: [this.houseModel.condition],
      grade: [this.houseModel.grade],
      yearBuilt: [this.houseModel.yearBuilt, [Validators.required, Validators.min(1800), Validators.max(<number>new Date().getFullYear()), Validators.pattern("^[0-9]*$")]],
      yearRenovated: [this.houseModel.yearRenovated, [Validators.required, , Validators.max(<number>new Date().getFullYear()), Validators.pattern("^[0-9]*$"), this.yearRenovatedIsGreaterThanBuilt('yearBuilt', 'yearRenovated')]],
      sqftAbove: [this.houseModel.sqftAbove, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]],
      sqftBasement: [this.houseModel.sqftAbove, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]]
    });
  }

  private inicijalizirajPodatkeZaUnos() : void{
    this.houseModel = {
      id: 0,
      price: 0,
      bedrooms: 0,
      bathrooms: 0,
      sqftLiving: 0,
      sqftLot: 0,
      floors: 0,
      view: 1,
      condition: 1,
      grade: 1,
      yearBuilt: 1800,
      yearRenovated: 0,
      sqftAbove: 0,
      sqftBasement: 0
    };
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

public odaradiOperaciju() : void {
  if(this.isAddMode){
    this.dodajNoviZapis();
  }else{
    this.azurirajTrenutniZapis();
  }
}

public dodajNoviZapis() : void{

  this.smtp.addNewHouse(this.houseModel).subscribe(
    success => {
      console.log("Server je vratio "+ success);
    },

    err => {
      console.log("Error: "+ err);
    }
  );
}

public azurirajTrenutniZapis() : void{

  this.smtp.updateHouse(this.houseModel, this.id).subscribe(
    response => {
      console.log("Pristigao je odgovor "+ response);
    },
    err => {
      console.log("Error: "+ err);
    }
  );
}

private odrediNacinRada() : void {
  this.id  = +this.route.snapshot.params['id']!;
  this.isAddMode = !this.id;
}

private dohvatiZapisZaEdit(){
  this.smtp.getHouseById(this.id).subscribe(
    response =>{
      this.houseModel = response;
      this.houseForm.patchValue(response);
    },
    error => {
      console.error("Dogodila se greška kod vraćanja: "+ error);
    }

  );
}

}
