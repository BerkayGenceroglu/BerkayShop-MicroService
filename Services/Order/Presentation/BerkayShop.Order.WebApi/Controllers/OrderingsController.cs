using BerkayShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using BerkayShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using BerkayShop.Order.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
         private readonly IMediator _mediator;
         private readonly IOrderingRepository _orderingRepository;

        public OrderingsController(IMediator mediator, IOrderingRepository orderingRepository)
        {
            _mediator = mediator;
            _orderingRepository = orderingRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderings()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        { 
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Silme İşlemi Başarıyla Gerçekleşti"); 
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        }

        //Özel Methodlar
        [HttpGet("GetOrderingByUserId/{userId}")]
        public async Task<IActionResult> GetOrderingByUserId(string userId)
        {
            var values = await _mediator.Send(new GetOrderingByUserIdQuery(userId));
            return Ok(values);
        }

        [HttpGet("GetOrderingTotalPrice")]
        public async Task<IActionResult> GetOrderingTotalPrice()
        {
            var totalPrice = await _orderingRepository.GetTotalOrderPriceCount();
            return Ok(totalPrice);
        }

        [HttpGet("GetLastOrderDate")]
        public async Task<IActionResult> GetLastOrderDate()
        {
            var LastOrderDate = await _orderingRepository.GetLastOrderDate();
            return Ok(LastOrderDate);
        }
    }
}
