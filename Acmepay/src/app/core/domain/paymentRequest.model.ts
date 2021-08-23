export interface paymentRequest {
    cardholderNumber: string,
    holderName: string,
    expirationMonth: number,
    expirationYear: number,
    amount: number,
    orderReference: string,
    CVV: number,
    currency: string
}