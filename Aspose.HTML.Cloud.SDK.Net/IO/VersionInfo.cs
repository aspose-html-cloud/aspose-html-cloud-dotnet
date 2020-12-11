using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.IO
{
    public class VersionInfo : IEnumerable<string>
    {
        private string LastVersion { get; }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}