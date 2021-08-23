import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { IPaymentRepository } from '../../core/repositories/IPayment.repository';
import { paymentResponse } from '../../core/domain/paymentResponse.model';
import { pagingWithDate } from 'src/app/core/domain/pagingWithDate.model';

@Injectable({
    providedIn: 'root'
})
export class PaymentRepository extends IPaymentRepository {

    private rootUrl: string = "https://localhost:44382/api/";

    constructor(private http: HttpClient) {
        super();
    }
    requestPayment(paymentRequest): Observable<paymentResponse> {
        return this.http.post<paymentResponse>(this.rootUrl + 'authorize', paymentRequest);
    }

    getPagedResponse(page: number, pageSize: number) {
        let httpParams = new HttpParams({
            fromObject: {
                page: page.toString(),
                pageSize: pageSize.toString()
            }
        })
        const options = { params: httpParams };
        return this.http.get(this.rootUrl + "transactions", options);
    }

    getPaymentCount() {
        return this.http.get(this.rootUrl + "transactions/getCount");
    }

    voidPayment(id: string): Observable<paymentResponse> {
        return this.http.get(this.rootUrl + "authorize/" + id + "/void");

    }

    capturePayment(id: string): Observable<paymentResponse> {
        return this.http.get(this.rootUrl + "authorize/" + id + "/capture");
    }

    filterByDate(startDate: Date, endDate: Date) {
        if (startDate != null)
            var start = startDate.toDateString();
        else
            var start = "";

        if (endDate != null)
            var end = endDate.toDateString();
        else
            var end = ""

            let httpParams = new HttpParams({
            fromObject: {
                startDate: start,
                endDate: end
            }
        })
        const options = { params: httpParams };
        return this.http.get(this.rootUrl + "transactions/filterByDate", options);
    }

    filterByStatus(statusCode: string) {
        let httpParams = new HttpParams({
            fromObject: {
                status: statusCode
            }
        })
        const options = { params: httpParams };
        return this.http.get(this.rootUrl + "transactions/filterByStatus", options);
    }

}