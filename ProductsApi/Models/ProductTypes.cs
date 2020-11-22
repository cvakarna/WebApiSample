using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Models
{
    /// <summary>
    /// Product types
    /// </summary>
    public class ProductTypes
    {
        /// <summary>
        /// List of available product types
        /// </summary>
        public static List<string> TYPES = new List<string>
        {
            "Mobiles",
            "Tvs"
        };
    }
}
