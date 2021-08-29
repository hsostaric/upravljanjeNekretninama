import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetaljiKuceComponent } from './detalji-kuce.component';

describe('DetaljiKuceComponent', () => {
  let component: DetaljiKuceComponent;
  let fixture: ComponentFixture<DetaljiKuceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetaljiKuceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetaljiKuceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
