using hotelapi.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace hotelapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();


        [HttpPost()]
        public async Task<ActionResult<dynamic>> Create(CreateHotelCommand request)
        {           
            var hotelId = await Mediator.Send(request);
            return Ok(new { IsSuccess = true, Id = hotelId });
        }
    }
}
