using ADA.Kanban.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace ADA.Kanban.Controllers
{
    [ApiController]
    [Route("cards")]
    [Authorize]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardService _cardService;

        public CardController(ILogger<CardController> logger, ICardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> Get()
        {
            try
            {
                var cards = await _cardService.GetCardsAsync();

                return Ok(cards);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred - Card > Get() > ErrorMessage: [{ex.Message}]");
                throw new Exception($"An error ocurred - Card > Get() > ErrorMessage: [{ex.Message}]");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Card>> Post([FromBody] Card card)
        {
            try
            {
                var newCard = new Card
                {
                    Id = Guid.NewGuid(),
                    Title = card.Title,
                    Content = card.Content,
                    List = card.List
                };

                await _cardService.CreateCardAsync(newCard);

                return Ok(newCard);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred - Card > Post() > ErrorMessage: [{ex.Message}]");
                return BadRequest();
            }
        }

        [HttpPut("{id:guid}")]
        [FilterLogging(action: "Atualizado")]
        public async Task<ActionResult<Card>> Put([FromRoute] Guid id, [FromBody] Card card)
        {
            try
            {
                var existingCard = await _cardService.GetCardByIdAsync(id);
                if (existingCard == null)
                    return NotFound($"Card with Id '{id}' not found!");

                if (id != card.Id)
                    return BadRequest($"Card Id '{id}' AND Id body '{card.Id}' must be the same!");

                await _cardService.UpdateCardAsync(id, card);

                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred - Card > Put() > ErrorMessage [{ex.Message}]");
                return BadRequest();
            }
        }

        [HttpDelete("{id:guid}")]
        [FilterLogging(action: "Removido")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var existingCard = await _cardService.GetCardByIdAsync(id);
                if (existingCard == null)
                    return NotFound($"Card with Id '{id}' not found!");

                var card = await _cardService.DeleteCardAsync(id);

                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred - Card > Delete() > ErrorMessage [{ex.Message}]");
                throw new Exception($"An error ocurred - Card > Delete() > ErrorMessage [{ex.Message}]");
            }
        }
    }
}
