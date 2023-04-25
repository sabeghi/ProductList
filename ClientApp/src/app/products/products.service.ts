import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Product } from "./Product";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiURL = "http://localhost:50016/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.apiURL + '/products')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getProduct(id): Observable<Product> {
    return this.httpClient.get<Product>(this.apiURL + '/products/' + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createProduct(Product): Observable<Product> {
    return this.httpClient.post<Product>(this.apiURL + '/products/', JSON.stringify(Product), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updateProduct(id, Product): Observable<Product> {
    return this.httpClient.put<Product>(this.apiURL + '/products/' + id, JSON.stringify(Product), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deleteProduct(id) {
    if (confirm("Are you sure to delete ")) {
      return this.httpClient.delete<Product>(this.apiURL + '/products/' + id, this.httpOptions)
        .pipe(
          catchError(this.errorHandler)
        );
    }
  }

  errorHandler(error) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
