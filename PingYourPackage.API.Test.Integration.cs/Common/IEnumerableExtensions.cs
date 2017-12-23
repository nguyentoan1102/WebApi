using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.API.Test.Integration.cs.Common
{
    internal static class IEnumerableExtensions
    {
        internal static IEnumerable<MediaTypeWithQualityHeaderValue> ToMediaTypeWithQualityHeaderValues(this IEnumerable<string> source)
        {

            foreach (var mediaType in source)
            {
                yield return new MediaTypeWithQualityHeaderValue(mediaType);
            }
        }
    }
}
