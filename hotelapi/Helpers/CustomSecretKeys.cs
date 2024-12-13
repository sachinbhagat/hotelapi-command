using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace hotelapi.Helpers;

public class CustomSecretKeys
{
    public static async Task<string> GetSecret()
    {
        string secretName = "HotelApiCommandTopic";
                
        IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName("us-east-1"));

        var request = new GetSecretValueRequest {
            SecretId = secretName,
            VersionStage = "AWSCURRENT", 
        };

        GetSecretValueResponse response;

        try
        {
            response = await client.GetSecretValueAsync(request);
        }
        catch (Exception e)
        {           
            throw e;
        }

        string secret = response.SecretString;
        return secret;
    }
}
