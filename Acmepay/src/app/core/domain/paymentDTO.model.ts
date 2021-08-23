export interface PaymentDTO {
    amount: number,
    cardholder_Number: string,
    currency: string,
    holderName: string,
    orderReference: string,
    paymentId: string
}
