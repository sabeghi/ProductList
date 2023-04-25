import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsAttributeComponent } from './products-attribute.component';

describe('ProductsAttributeComponent', () => {
  let component: ProductsAttributeComponent;
  let fixture: ComponentFixture<ProductsAttributeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductsAttributeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsAttributeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
