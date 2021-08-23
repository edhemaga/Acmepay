import { Observable } from 'rxjs';
import { Cardholder } from '../domain/cardholder.model';

export abstract class ICardHolderRepository {
    abstract addCardHolder(newCardholder: Cardholder): Observable<Cardholder>;
}
