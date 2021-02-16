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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public ApiParameter(string name, TValue value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Parameter name. Read-only property.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Parameter value. Read-only property.
        /// </summary>
        public TValue Value { get; protected set; }
    }


}
