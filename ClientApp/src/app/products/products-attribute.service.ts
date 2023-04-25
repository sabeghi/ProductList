import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ProductsAttribute } from "./products-attribute";

@Injectable({
  providedIn: 'root'
})
export class ProductsAttributeService {

  private apiURL = "http://localhost:50016/api";

  constructor(private httpClient: HttpClient) { }

  getProductsattribute(id): Observable<ProductsAttribute[]> {
    return this.httpClient.get<ProductsAttribute[]>(this.apiURL + '/ProductAttribute/' + id)
      .pipe(
        catchError(this.errorHandler)
      );
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
