using Amazon.DynamoDBv2.DataModel;

namespace hotelapi.Models;

[DynamoDBTable("Hotels")]
public class Hotel
{
    [DynamoDBHashKey("Id")]      
    public string Id { get; set; }

    [DynamoDBRangeKey("Name")]
    public string Name { get; set; }
    public int Price { get; set; }
    public int Rating { get; set; }
    public string City { get; set; }
}
