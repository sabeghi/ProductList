import { TestBed } from '@angular/core/testing';

import { ProductsAttributeService } from './products-attribute.service';

describe('ProductsAttributeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductsAttributeService = TestBed.get(ProductsAttributeService);
    expect(service).toBeTruthy();
  });
});
