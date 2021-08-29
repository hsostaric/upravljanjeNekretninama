import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { map } from 'rxjs/operators';
import { House } from 'src/app/interfaces/house';
import { SimpleRestService } from 'src/app/services/simplerest.service';

@Component({
  selector: 'pregled-kuca',
  templateUrl: './pregled-kuca.component.html',
  styleUrls: ['./pregled-kuca.component.scss']
})
export class PregledKucaComponent implements OnInit {

  public houses : House[] = [];
  public totalCounts : number = 0;
  public pageEvent !: PageEvent;
  public sortEvent !: Sort;
  public itemsPerPage : number = 25;
  public page : number = 1;
  public loading : boolean = false;
  public sortingColumn : string ="id";
  public sortingDirection : string ="asc";
  public donjaCijena : string = "";
  public gornjaCijena : string = "";
  displayedColumns : string [] = [ 'id', 'price', 'bedrooms', 'bathrooms', 'sqftLot', 'condition', 'grade', 'yearBuilt', 'detalji', 'brisanje', 'edit'];
  constructor(private smtp : SimpleRestService) { }

  ngOnInit(): void {
    this.loading=true;
    this.dohvatiBrojZapisa(this.gornjaCijena, this.donjaCijena);
    this.dohvatiKuceSaServera(this.sortingColumn, this.sortingDirection, this.page, this.itemsPerPage, this.donjaCijena, this.gornjaCijena);
  }

  public dohvatiBrojZapisa(donjaGranica: string, gornjaGranica : string) : void{
    this.smtp.getTotalCounts(donjaGranica, gornjaGranica)
    .subscribe((response:number)=>{
      this.totalCounts=response;
    });
  }

  public dohvatiKuceSaServera(column:string, direction: string, page:number, limit:number, donjaCijena : string, gornjaCijena : string) : void{
    this.smtp.getHousesFromDatabase(column, direction, page, limit, donjaCijena, gornjaCijena).subscribe(
      (response) => {
        this.houses = response;
        this.loading = false;
      }
    );
  }

  public obrisiZapis(id : number) : void {
    this.smtp.deleteHouseById(id).subscribe(
      (response) => {
        if(response){
          this.dohvatiKuceSaServera(this.sortingColumn, this.sortingDirection, this.page, this.itemsPerPage, this.donjaCijena, this.gornjaCijena);
        }
      });
  }

  public onPaginateChange(event: PageEvent) : void{
    this.page = event.pageIndex;
    this.page += 1;
    this.itemsPerPage = event.pageSize;
    this.dohvatiKuceSaServera(this.sortingColumn, this.sortingDirection, this.page, this.itemsPerPage, this.donjaCijena, this.gornjaCijena);
  }

  public onSortChange(event : Sort){
    if(!event.active && event.direction === ""){
      this.sortingColumn = "id";
      this.sortingDirection = "asc";
    }
    else{
      this.sortingColumn = event.active;
      this.sortingDirection = event.direction;
  }
    this.dohvatiBrojZapisa(this.gornjaCijena, this.donjaCijena);
    this.dohvatiKuceSaServera(this.sortingColumn, this.sortingDirection, this.page, this.itemsPerPage,this.donjaCijena, this.gornjaCijena );
  }

  public ponistiPretragu() : void{
    this.donjaCijena="";
    this.gornjaCijena="";
    this.sortingColumn = "id";
    this.sortingDirection = "asc";
    this.page = 1;
    this.itemsPerPage = 25;
    this.dohvatiBrojZapisa(this.gornjaCijena, this.donjaCijena);
    this.dohvatiKuceSaServera(this.sortingColumn, this.sortingDirection, this.page, this.itemsPerPage, this.donjaCijena, this.gornjaCijena);
  }

  public odradiPretragu() : void{
    if(this.donjaCijena == "" && this.gornjaCijena == ""){
      return;
    }
    this.page = 1;
    this.dohvatiBrojZapisa(this.donjaCijena, this.gornjaCijena);
    this.dohvatiKuceSaServera(this.sortingColumn, this.sortingDirection, 1, this.itemsPerPage, this.donjaCijena, this.gornjaCijena)
  }

}
