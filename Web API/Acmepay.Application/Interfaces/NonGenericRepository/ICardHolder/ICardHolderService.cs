using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acmepay.Application.DTOs.CardHolder;
using Acmepay.Domain.Entities;

namespace Acmepay.Application.Interfaces.NonGenericRepository.ICardHolder
{
    public interface ICardHolderService
    {
        public Task AddCardHolder(CardHolderDTO cardHolder);
        public Task<IList<CardHolder>> GetAllCardHolders();
        public Task<CardHolder> GetCardHolder(Guid Id);
        public Task DeleteCardHolder(Guid id);
    }
}