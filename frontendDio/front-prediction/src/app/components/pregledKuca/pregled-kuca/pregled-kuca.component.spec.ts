import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledKucaComponent } from './pregled-kuca.component';

describe('PregledKucaComponent', () => {
  let component: PregledKucaComponent;
  let fixture: ComponentFixture<PregledKucaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledKucaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledKucaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
