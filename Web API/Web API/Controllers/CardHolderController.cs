using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmepay.Application.DTOs.CardHolder;
using Acmepay.Application.Interfaces.NonGenericRepository.ICardHolder;
using Acmepay.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("cardholder")]
    [ApiController]
    public class CardHolderController : ControllerBase
    {
        private readonly ICardHolderService _cardHolderService;

        public CardHolderController(ICardHolderService cardHolderService)
        {
            _cardHolderService = cardHolderService;
        }

        [HttpGet]
        public List<CardHolder> GetAllCardholders()
        {
            return _cardHolderService.GetAllCardHolders().Result.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddCardHolder(CardHolderDTO cardHolder)
        {
            await _cardHolderService.AddCardHolder(cardHolder);
            return Ok();
        }
    }
}