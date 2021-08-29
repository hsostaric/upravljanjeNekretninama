import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { House } from '../interfaces/house';
import { config, Observable, throwError } from 'rxjs';
import { AppConfig } from '../config/config';
import { PropertiesKeys } from '../enum/propertiesKeys';
import { HouseElements } from '../interfaces/houseElements';
import {  map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SimpleRestService {
  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private httpClient: HttpClient, private config: AppConfig) { }
  private baseUri: string = this.config.setting[PropertiesKeys.PATH_API];

  public postPredictionValue(houseValues: HouseElements): Observable<any> {
    return this.httpClient.post<any>(this.baseUri + '/prediction', JSON.stringify(houseValues), this.httpHeader);
  }

  public getHousesFromDatabase(column:string, direction:string, page:number, size:number, donjaGranica:string, gornjaGranica:string) : Observable<House[]>{
    let params : HttpParams = new HttpParams();
    params = params.append('column', column);
    params = params.append('direction', direction);
    params = params.append('page', +page);
    params =params.append('size', +size);
    if(donjaGranica != ""){
      if(+donjaGranica >=0){
        params = params.append("donjaGranica", +donjaGranica);
      }
    }
    if(gornjaGranica != ""){
      if(+donjaGranica >= 0){
        params = params.append("gornjaGranica", +gornjaGranica);
      }
    }

    return this.httpClient.get<House[]>(this.baseUri, {responseType: 'json', params}).pipe(
      map((response : any) => {
           return <House[]>response.data;
      })
    );
  }

  public getHouseById(id: number) : Observable<House>{
    let url = `${this.baseUri}/${id}`;
    return this.httpClient.get<House>(url, {responseType: 'json'}).pipe(map(
      (response : any) => {
        return <House>response;
      }));
  }

  public addNewHouse(body : House): Observable<boolean>{
    let pom = {
      price: +body.price,
	    bedrooms: +body.bedrooms,
	    bathrooms: +body.bathrooms,
	    sqftLiving: +body.sqftLiving,
	    sqftLot: +body.sqftLot,
	    floors: +body.floors,
	    view: +body.view,
	    condition: +body.condition,
	    grade: +body.grade,
	    yearBuilt: +body.yearBuilt,
	    yearRenovated: +body.yearRenovated,
	    sqftAbove: +body.sqftAbove,
	    sqftBasement: +body.sqftBasement
    };
    return this.httpClient.post<boolean>(this.baseUri, JSON.stringify(pom) ,this.httpHeader).pipe(
      map((response : any) =>{
        return <boolean> response.success;
      } ));
  }

  public updateHouse(body:House, id:number) : Observable<boolean>{
    let url = `${this.baseUri}/${id}`;
    let pom = {
      price: +body.price,
	    bedrooms: +body.bedrooms,
	    bathrooms: +body.bathrooms,
	    sqftLiving: +body.sqftLiving,
	    sqftLot: +body.sqftLot,
	    floors: +body.floors,
	    view: +body.view,
	    condition: +body.condition,
	    grade: +body.grade,
	    yearBuilt: +body.yearBuilt,
	    yearRenovated: +body.yearRenovated,
	    sqftAbove: +body.sqftAbove,
	    sqftBasement: +body.sqftBasement
    };
    return this.httpClient.put(url,JSON.stringify(pom),this.httpHeader).pipe((
      map((response:any) => {
        return <boolean>response.success;
      })));
  }

  public deleteHouseById(id : number) : Observable<boolean>{
    let url = `${this.baseUri}/${id}`;
    return this.httpClient.delete<boolean>(url, this.httpHeader).pipe(
      (map((response : any) => {
          return response.success;
      })));
  }

  public getTotalCounts(donjaGranica : string, gornjaGranica : string) : Observable<number>{
    let params : HttpParams = new HttpParams();
    if(donjaGranica != ""){
      if(+donjaGranica >=0){
        params = params.append("donjaGranica", +donjaGranica);
      }
    }
    if(gornjaGranica != ""){
      if(+donjaGranica >= 0){
        params = params.append("gornjaGranica", +gornjaGranica);
      }
    }
    return this.httpClient.get(this.baseUri + "/totalData", {responseType:"json", params}).pipe(
      (map((response : any) => {
      return <number>response;
    })));
  }
}
