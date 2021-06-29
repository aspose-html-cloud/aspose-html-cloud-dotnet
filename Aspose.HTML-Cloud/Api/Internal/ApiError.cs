using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class ApiError
    {
        /// <summary>
        /// Gets or sets api error code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets error description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets server datetime.
        /// </summary>
        [JsonProperty("dateTime")]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Gets or sets inner error.
        /// </summary>
        [JsonProperty("innerError")]
        public ApiError InnerError { get; set; }
    }
}
