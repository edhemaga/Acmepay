using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmepay.Application.DTOs;
using Acmepay.Application.DTOs.CardHolder;
using Acmepay.Application.DTOs.Payment;
using Acmepay.Application.Interfaces.NonGenericRepository.ICardHolder;
using Acmepay.Domain.Entities;
using WMS.Application.Interfaces.GenericRepository;

namespace Acmepay.Infrastructure.Shared.CardHolderService
{
    public class CardHolderService : ICardHolderService
    {
        private readonly IGenericRepository<CardHolder> _cardHolderRepository;

        public CardHolderService(IGenericRepository<CardHolder> cardHolderRepository)
        {
            _cardHolderRepository = cardHolderRepository;
        }

        public async Task AddCardHolder(CardHolderDTO cardHolder)
        {
            var newCardHolder = new CardHolder()
            {
                Cardholder_Number = cardHolder.CardholderNumber.Trim(),
                HolderName = cardHolder.HolderName.Trim(),
                ExpirationMonth = cardHolder.ExpirationMonth,
                ExpirationYear = cardHolder.ExpirationYear,
                CVV = cardHolder.CVV
            };
            await _cardHolderRepository.AddAsync(newCardHolder);
        }
       
        public async Task<IList<CardHolder>> GetAllCardHolders()
        {
            return _cardHolderRepository.GetAllAsync().Result.ToList();
        }

        public Task<CardHolder> GetCardHolder(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCardHolder(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}