import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddorupdatehouseComponent } from './addorupdatehouse.component';

describe('AddorupdatehouseComponent', () => {
  let component: AddorupdatehouseComponent;
  let fixture: ComponentFixture<AddorupdatehouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddorupdatehouseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddorupdatehouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
