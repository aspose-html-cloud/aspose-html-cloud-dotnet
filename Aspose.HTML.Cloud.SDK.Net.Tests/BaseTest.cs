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
                new Configuration("5add06cf-9af7-44f6-b180-dfcc2583cfcb", "71a5b89b3f83cd39195d7fc39382babd");
        }
    }
}
