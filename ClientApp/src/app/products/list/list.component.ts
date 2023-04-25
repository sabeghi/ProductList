import { Component, OnInit } from '@angular/core';
import { Product } from "../Product";
import { ProductsService } from "../products.service";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  Products: Product[] = [];

  constructor(public ProductsService: ProductsService) { }

  ngOnInit(): void {
    this.ProductsService.getProducts().subscribe((data: Product[]) => {
      this.Products = data;
    });
  }

  deleteProduct(id) {
    this.ProductsService.deleteProduct(id).subscribe(res => {
      this.Products = this.Products.filter(item => item.id !== id);
    });
  }

}
