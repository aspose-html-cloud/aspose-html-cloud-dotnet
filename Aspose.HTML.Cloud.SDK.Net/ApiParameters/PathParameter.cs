using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.ApiParameters
{
    /// <summary>
    /// Abstract class that represents local or remote directory path parameter.
    /// </summary>
    public abstract class PathParameter : ApiParameter<string>
    {
        protected PathParameter(string name, string path)
            : base(name, path)
        { }

        public virtual string Path
        {
            get { return Value; }
        }
    }
}
