using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acmepay.Application.DTOs.Payment;
using Acmepay.Domain.Entities;

namespace Acmepay.Application.Interfaces.NonGenericRepository.IPayment
{
    public interface IPaymentService
    {
        public Task<IList<Payment>> GetAllPayments();
        public Task<Payment> GetPayment(Guid id);
        public Task<List<PaymentDTO>> FilterByStatus(String status);
        public Task<List<PaymentDTO>> FilterByDate(DateTime startDateTime, DateTime endDateTime);
        public Task<List<PaymentDTO>> GetPagedTransactions(int pageSize, int page);
        public Task<PaymentResponseDTO> MakePayment(PaymentRequestDTO paymentRequestDto);
        public Task<PaymentResponseDTO> VoidPayment(Guid id);
        public Task<PaymentResponseDTO> CapturePayment(Guid id);
        public int GetPaymentCount();
    }
}