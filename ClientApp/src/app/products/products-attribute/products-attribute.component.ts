import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from "../Product";
import { ProductsAttribute } from '../products-attribute';
import { ProductsAttributeService } from "../products-attribute.service";

@Component({
  selector: 'app-products-attribute',
  templateUrl: './products-attribute.component.html',
  styleUrls: ['./products-attribute.component.css']
})
export class ProductsAttributeComponent implements OnInit {

  id: number;
  productattr: ProductsAttribute[] = [];

  constructor(
    public productsAttributeService: ProductsAttributeService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['productId'];
    this.productsAttributeService.getProductsattribute(this.id).subscribe((data: ProductsAttribute[]) => {
      console.log(data);
      this.productattr = data;
      //this.productattr = data.filter(item => item.id !== this.id);
      console.log(this.productattr);
    });
  }

}
