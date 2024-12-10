using hotelapi.Events;
using hotelapi.Models;
using hotelapi.Services;
using MediatR;

namespace hotelapi.Commands;

public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, Guid>
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IHotelService _hotelService;
    public CreateHotelCommandHandler(IEventPublisher eventPublisher, IHotelService hotelService)
    {
        _eventPublisher = eventPublisher;
        _hotelService = hotelService;
    }
    
   async Task<Guid> IRequestHandler<CreateHotelCommand, Guid>.Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        Guid Id = Guid.NewGuid();

        var hotel = new Hotel()
        {
            Id = Id.ToString(),
            Name = request.Name,
            Price = request.Price,
            Rating = request.Rating,
            City = request.City
        };

        _hotelService.AddHotel(hotel);

        var createdEvent = new HotelCreatedEvent
        {
            Id = Id.ToString(),
            Name = request.Name,
            Price = request.Price,
            Rating = request.Rating,
            City = request.City,
            CreatedDate = DateTime.UtcNow,
        };
      
        await _eventPublisher.PublishAsync(createdEvent);

        return Id;
    }
}


