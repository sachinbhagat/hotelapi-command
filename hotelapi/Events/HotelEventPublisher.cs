using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using hotelapi.Helpers;

namespace hotelapi.Events
{
    public class HotelEventPublisher  : IEventPublisher
    {
        // AWS Configuration
       // string topicArn = "arn:aws:sns:eu-west-2:920373003334:hotel-topic";
        private readonly AmazonSimpleNotificationServiceClient snsClient;

        public HotelEventPublisher()
        {
            snsClient = new AmazonSimpleNotificationServiceClient(RegionEndpoint.GetBySystemName("us-east-1"));
        }

        public async Task PublishAsync(HotelCreatedEvent createdEvent)
        {
            try
            {
                var topicArn = await CustomSecretKeys.GetSecret();
                // Publish the message to SNS
                var publishRequest = new PublishRequest
                {
                    TopicArn = topicArn,
                    Message = System.Text.Json.JsonSerializer.Serialize(createdEvent),
                    Subject = "Event Notification: HotelCreated"
                };
                try
                {
                    var response = await snsClient.PublishAsync(publishRequest);
                    // Check response
                    Console.WriteLine($"Message sent to SNS. MessageId: {response.MessageId}");
                }
                catch (Exception ex)
                {

                    throw;
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to publish message: {ex.Message}");
            }
           
        }
    }
}
