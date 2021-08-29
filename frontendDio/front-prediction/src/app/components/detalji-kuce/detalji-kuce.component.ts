import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SimpleRestService } from 'src/app/services/simplerest.service';
import { Location } from '@angular/common';
import { House } from 'src/app/interfaces/house';

@Component({
  selector: 'app-detalji-kuce',
  templateUrl: './detalji-kuce.component.html',
  styleUrls: ['./detalji-kuce.component.scss']
})
export class DetaljiKuceComponent implements OnInit {

  public house !: House;
  constructor(private smtp : SimpleRestService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    this.getHouseById();
  }

  public getHouseById() : void{
    let id = +this.route.snapshot.paramMap.get('id')!;
    if(id != undefined){
        this.smtp.getHouseById(id).subscribe((response) => {
          if(response == undefined || response == null){
            this.location.back();
          }
          else{
            this.house = response;
          }
        });
    }else{
      this.location.back();
    }

  }

  public nazad():void{
    this.location.back()
  }

}
