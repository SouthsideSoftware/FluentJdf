using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FluentJdf.Configuration;

namespace FluentJdf.Transmission {
    /// <summary>
    /// Factory used to create <see cref="HttpWebRequest"/> objects.
    /// </summary>
    public interface IHttpWebRequestFactory {
        /// <summary>
        /// Create a web request.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        HttpWebRequest Create(Uri uri, string contentType);
    }
}
