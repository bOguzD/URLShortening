using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortening.Service.Exceptions
{
    public class UrlValidationException: Exception
    {
        public UrlValidationException(string message) : base(message) { }
    }
}
