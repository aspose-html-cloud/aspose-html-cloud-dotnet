using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    /// <summary>
    /// Interface that joins all HTML SDK API methods
    /// </summary>
    public interface IHtmlApi : 
        IDocumentApi, IConversionApi, IOcrApi, ISummarizationApi, ITranslationApi, ITemplateMergeApi
    {
    }
}
