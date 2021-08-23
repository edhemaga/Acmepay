using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmepay.Application.DTOs.Payment;
using Acmepay.Application.Interfaces.NonGenericRepository.IPayment;
using Acmepay.Domain.Entities;
using WMS.Application.Interfaces.GenericRepository;

namespace Acmepay.Infrastructure.Shared.PaymetService
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentService;
        private readonly IGenericRepository<CardHolder> _cardHolderService;

        public PaymentService(IGenericRepository<Payment> paymentService,
            IGenericRepository<CardHolder> cardHolderService)
        {
            _paymentService = paymentService;
            _cardHolderService = cardHolderService;
        }

        public async Task<IList<Payment>> GetAllPayments()
        {
            var allPayments = await _paymentService.GetAllAsync();
            return allPayments.ToList();
        }

        public async Task<Payment> GetPayment(Guid id)
        {
            return await _paymentService.GetByGuidAsync(id);
        }

        public async Task<PaymentResponseDTO> MakePayment(PaymentRequestDTO paymentRequestDto)
        {
            var cardHolders = _cardHolderService.IncludeAll().ToList();
            if (cardHolders.ToList().Count != 0)
            {
                foreach (var cardHolder in cardHolders)
                {
                    if (cardHolder.Cardholder_Number == paymentRequestDto.CardholderNumber.Trim() &&
                        cardHolder.HolderName == paymentRequestDto.HolderName.Trim())
                    {
                        if (new DateTime(paymentRequestDto.ExpirationYear, paymentRequestDto.ExpirationMonth, 1) >=
                            DateTime.Now)
                        {
                            var newPayment = new Payment()
                            {
                                Amount = paymentRequestDto.Amount,
                                OrderReference = paymentRequestDto.OrderReference,
                                CardHolderId = cardHolder.Id,
                                Currency = paymentRequestDto.Currency,
                                Status = Status.Authorized,
                                CreatedOn = DateTime.Now
                            };
                            var payment = await _paymentService.AddAsync(newPayment);
                            return (new PaymentResponseDTO() {Id = payment.Id, Status = Status.Authorized.ToString()});
                        }
                    }
                }
            }

            throw new Exception("Payment could not be authenticated!");
        }

        public async Task<PaymentResponseDTO> VoidPayment(Guid id)
        {
            var paymentToVoid = await _paymentService.GetByGuidAsync(id);
            if (paymentToVoid != null)
            {
                paymentToVoid.Status = Status.Voided;
                await _paymentService.UpdateAsync(paymentToVoid);
                return (new PaymentResponseDTO() {Id = paymentToVoid.Id, Status = paymentToVoid.Status.ToString()});
            }
            else
            {
                throw new Exception($"Payment with {id} could not be found!");
            }
        }

        public async Task<List<PaymentDTO>> FilterByStatus(String status)
        {
            var allPayment = await _paymentService.GetAllAsync();
            var paymentDTOs = new List<PaymentDTO>();

            foreach (var payment in allPayment)
            {
                if (payment.Status.ToString() == status)
                {
                    var cardHolder = await _cardHolderService.GetByGuidAsync(payment.CardHolderId);
                    if (cardHolder != null)
                    {
                        var paymentDTO = new PaymentDTO()
                        {
                            PaymentId = payment.Id,
                            Amount = payment.Amount,
                            Currency = payment.Currency,
                            OrderReference = payment.OrderReference,
                            Cardholder_Number = cardHolder.Cardholder_Number,
                            HolderName = cardHolder.HolderName,
                            Status = payment.Status.ToString()
                        };
                        paymentDTOs.Add(paymentDTO);
                    }
                }
            }

            return paymentDTOs;
        }

        public async Task<List<PaymentDTO>> FilterByDate(DateTime startDateTime, DateTime endDateTime)
        {
            var allPayment = await _paymentService.GetAllAsync();
            var paymentDTOs = new List<PaymentDTO>();
            var paymentTemp = new List<Payment>();

            if (startDateTime != default && endDateTime != default)
            {
                foreach (var payment in allPayment)
                {
                    if (payment.CreatedOn >= startDateTime && payment.CreatedOn <= endDateTime)
                    {
                        paymentTemp.Add(payment);
                    }
                }
            }
            else if (startDateTime != default && endDateTime == default)
            {
                foreach (var payment in allPayment)
                {
                    if (payment.CreatedOn >= startDateTime)
                    {
                        paymentTemp.Add(payment);
                    }
                }
            }
            else if (startDateTime == default && endDateTime != default)
            {
                foreach (var payment in allPayment)
                {
                    if (payment.CreatedOn <= endDateTime)
                    {
                        paymentTemp.Add(payment);
                    }
                }
            }
            else
            {
                return paymentDTOs;
            }

            foreach (var payment in paymentTemp)
            {
                var cardHolder = await _cardHolderService.GetByGuidAsync(payment.CardHolderId);
                if (cardHolder != null)
                {
                    var paymentDTO = new PaymentDTO()
                    {
                        PaymentId = payment.Id,
                        Amount = payment.Amount,
                        Currency = payment.Currency,
                        OrderReference = payment.OrderReference,
                        Cardholder_Number = cardHolder.Cardholder_Number,
                        HolderName = cardHolder.HolderName,
                        Status = payment.Status.ToString()
                    };
                    paymentDTOs.Add(paymentDTO);
                }
            }

            return paymentDTOs;
        }

        public async Task<List<PaymentDTO>> GetPagedTransactions(int pageSize, int page)
        {
            var allPayment = await _paymentService.GetAllAsync();
            var paymentDTOs = new List<PaymentDTO>();
            var paginatedPayments = allPayment.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            foreach (var payment in paginatedPayments)
            {
                var cardHolder = await _cardHolderService.GetByGuidAsync(payment.CardHolderId);
                if (cardHolder != null)
                {
                    var paymentDTO = new PaymentDTO()
                    {
                        PaymentId = payment.Id,
                        Amount = payment.Amount,
                        Currency = payment.Currency,
                        OrderReference = payment.OrderReference,
                        Cardholder_Number = cardHolder.Cardholder_Number,
                        HolderName = cardHolder.HolderName,
                        Status = payment.Status.ToString()
                    };
                    paymentDTOs.Add(paymentDTO);
                }
            }

            return paymentDTOs;
        }

        public async Task<PaymentResponseDTO> CapturePayment(Guid id)
        {
            var paymentToCapture = await _paymentService.GetByGuidAsync(id);
            if (paymentToCapture != null)
            {
                paymentToCapture.Status = Status.Captured;
                await _paymentService.UpdateAsync(paymentToCapture);
                return (new PaymentResponseDTO()
                    {Id = paymentToCapture.Id, Status = paymentToCapture.Status.ToString()});
            }
            else
            {
                throw new Exception($"Payment with {id} could not be found!");
            }
        }

        public int GetPaymentCount()
        {
            return _paymentService.GetAllAsync().Result.Count;
        }
    }
}