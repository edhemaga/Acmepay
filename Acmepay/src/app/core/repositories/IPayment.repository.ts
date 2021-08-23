import { Observable } from 'rxjs';
import { paymentRequest } from '../domain/paymentRequest.model';
import { paymentResponse } from '../domain/paymentResponse.model';
import { pagingWithDate } from 'src/app/core/domain/pagingWithDate.model';

export abstract class IPaymentRepository {
    abstract requestPayment(paymentRequest: paymentRequest): Observable<paymentResponse>;
    abstract getPagedResponse(page: number, pageSize: number);
    abstract capturePayment(id: string): Observable<paymentResponse>;
    abstract voidPayment(id: string): Observable<paymentResponse>;
    abstract filterByStatus(status: string);
    abstract filterByDate(startDate: Date, endDate: Date);
    abstract getPaymentCount();
}
