using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.ApiParameters
{
    /// <summary>
    /// Base class of all customizable parameter object classes.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class ApiParameter<TValue>
    {
        public ApiParameter(string name, TValue value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; protected set; }

        public TValue Value { get; protected set; }
    }


}
