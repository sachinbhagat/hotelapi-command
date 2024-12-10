namespace hotelapi.Events;

public class HotelCreatedEvent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Rating { get; set; }
    public string City { get; set; }
    public DateTime CreatedDate { get; set; }
}
