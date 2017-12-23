using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.API.Test.Integration.cs.Common
{
    internal static class ICollectionExtensions
    {
        internal static void AddTo<T>(this ICollection<T> destination, IEnumerable<T> source)
        {

            foreach (T item in source)
            {
                destination.Add(item);
            }
        }
    }
}
