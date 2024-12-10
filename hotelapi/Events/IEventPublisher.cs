namespace hotelapi.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync(HotelCreatedEvent createdEvent);
    }
}
