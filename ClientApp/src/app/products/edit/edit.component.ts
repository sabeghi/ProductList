import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Product } from "../Product";
import { Category } from "../Category";
import { ProductsService } from "../products.service";
import { CategoriesService } from "../categories.service";

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  id: number;
  product: Product;
  categories: Category[] = [];
  editForm;

  constructor(
    public productsService: ProductsService,
    public categoriesService: CategoriesService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      id: [''],
      code: ['', Validators.required],
      name: ['', Validators.required],
      Category: [''],
      presentable: [''],
      description: ['']
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['productId'];

    this.categoriesService.getCategories().subscribe((data: Category[]) => {
      this.categories = data;
    });

    this.productsService.getProduct(this.id).subscribe((data: Product) => {
      this.product= data;
      this.editForm.patchValue(data);
    });
  }

  onSubmit(formData) {
    console.log(formData.value);
    this.productsService.updateProduct(this.id, formData.value).subscribe(res => {
      this.router.navigateByUrl('products/list');
    });
  }
}
