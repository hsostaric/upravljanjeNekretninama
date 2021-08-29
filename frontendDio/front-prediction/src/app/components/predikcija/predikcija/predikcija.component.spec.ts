import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PredikcijaComponent } from './predikcija.component';

describe('PredikcijaComponent', () => {
  let component: PredikcijaComponent;
  let fixture: ComponentFixture<PredikcijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PredikcijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PredikcijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
