using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExODataBind.Utils
{
    public static class TokenGenerator
    {
        public static string GenerateRandomId()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
