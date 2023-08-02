using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationErrorException
{
    public class ErrorDictionary
    {
        public enum GeneralCodes
        {
            ModelStateInvalid = 101,
            DataNotFound = 102,
            HttpClientError = 103,
            UnexpectedError = 999
        }
    }
}
