import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddorupdatehouseComponent } from './components/addorupdatehouse/addorupdatehouse.component';
import { DetaljiKuceComponent } from './components/detalji-kuce/detalji-kuce.component';
import { PredikcijaComponent } from './components/predikcija/predikcija/predikcija.component';
import { PregledKucaComponent } from './components/pregledKuca/pregled-kuca/pregled-kuca.component';

const routes: Routes = [
{
  path: '', redirectTo: 'pregled-kuca', pathMatch: 'full'
},
{
  path: 'pregled-kuca', component: PregledKucaComponent
}
,
{
  path: 'predikcija', component: PredikcijaComponent
},
{path: 'detail/:id', component: DetaljiKuceComponent},
{path : 'novi', component:AddorupdatehouseComponent},
{path : 'edit/:id', component: AddorupdatehouseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
