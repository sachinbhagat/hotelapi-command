
namespace hotelapi.Commands;

public class CreateHotelCommand : MediatR.IRequest<Guid>
{  
    public string Name { get; set; }
    public int Price { get; set; }
    public int Rating { get; set; }
    public string City { get; set; }
}


