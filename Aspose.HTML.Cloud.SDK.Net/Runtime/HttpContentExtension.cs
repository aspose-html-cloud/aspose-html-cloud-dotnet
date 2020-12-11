using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Net.Http
{
    public static class HttpContentExtension
    {
        public static string GetContentAs(this HttpContent content)
        {
            return content.ReadAsStringAsync().Result;
        }
    }
}
