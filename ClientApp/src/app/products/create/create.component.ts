import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Category } from "../Category";
import { ProductsService } from "../products.service";
import { CategoriesService } from '../categories.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  categories: Category[] = [];
  createForm;

  constructor(
    public productService: ProductsService,
    public categoriesService: CategoriesService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.createForm = this.formBuilder.group({
      code: ['', Validators.required],
      name: ['', Validators.required],
      Category: [''],
      presentable: [''],
      description: [''],
    });
  }

  ngOnInit(): void {
    this.categoriesService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
    });
  }

  onSubmit(formData) {
    console.log(formData.value);
    this.productService.createProduct(formData.value).subscribe(res => {
      this.router.navigateByUrl('products/list');
    });
  }
}
