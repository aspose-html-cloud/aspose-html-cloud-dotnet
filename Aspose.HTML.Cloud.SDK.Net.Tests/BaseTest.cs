namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class BaseTest
    {
        public string ClientId => configuration.ClientId;
        public string ClientSecret => configuration.ClientSecret;

        private readonly Configuration configuration;

        public BaseTest()
        {
            configuration =
                new Configuration("client_id", "client_secret");
        }
    }
}
