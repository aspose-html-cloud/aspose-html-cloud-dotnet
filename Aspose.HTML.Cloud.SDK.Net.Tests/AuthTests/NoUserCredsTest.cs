using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using System.Threading;
using Aspose.HTML.Cloud.Sdk.IO;
using Xunit;
using Assert = Xunit.Assert;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Microsoft.Extensions.Configuration;
namespace Aspose.HTML.Cloud.Sdk.Tests.AuthTests
{
    public class NoUserCredsTest
    {

        public NoUserCredsTest()
        { }

        [Fact]
        public void NoUserCredsSpecified()
        {
            var ex = Assert.Throws<ApiException>(() =>
            {
                // API entry point inited without user credentials
                using(var api = new HtmlApi(new Configuration()))
                {
                    // never will be reached in this test
                    api.Storage.GetDirectories("/");
                }
            });
            Assert.Equal(401, ex.ErrorCode);
            Assert.Equal(HtmlApi.ERRMSG_NOUSERCREDS, ex.Message);
        }

    }
}
