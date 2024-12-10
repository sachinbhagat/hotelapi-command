using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace hotelapi.Services;

public class HotelService : IHotelService
{    
    private readonly DynamoDBContext _dBContext;
    
    public HotelService()
    {
        var dynamoDBclient = new AmazonDynamoDBClient();
        //new AmazonDynamoDBClient(AwsConfiguration.AccessKeyId, AwsConfiguration.SecretAccessKey, AwsConfiguration.Region);
        _dBContext = new DynamoDBContext(dynamoDBclient);
    }

    public async void AddHotel(Models.Hotel hotel)
    {       
       await _dBContext.SaveAsync(hotel);    
    }
}
