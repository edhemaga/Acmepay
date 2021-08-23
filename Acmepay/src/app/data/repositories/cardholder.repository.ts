import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ICardHolderRepository } from '../../core/repositories/ICardHolder.repository';
import { Cardholder } from '../../core/domain/cardholder.model';


@Injectable({
    providedIn: 'root'
})
export class CardholderRepository extends ICardHolderRepository {
    private rootUrl: string = "https://localhost:44382/";

    constructor(private http: HttpClient) {
        super();
    }
    addCardHolder(newCardholder): Observable<Cardholder> {
        return this.http.post<Cardholder>(this.rootUrl + 'cardholder', newCardholder);
    }

}