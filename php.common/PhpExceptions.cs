using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php.common
{
    public class PhpExceptions:Exception
    {
        public ErrorCode ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public PhpExceptions(ErrorCode code, Exception innerException) : base(code.ToString(), innerException)
        {
            ErrorCode = code;
            ErrorMessage = code.ToString().Replace("_", " ");
        }

        public PhpExceptions(string message)
        {

            ErrorMessage = message;
        }

        public static void Throw(ErrorCode code, Exception innerException)
        {
            throw new PhpExceptions(code, innerException);
        }

        public static void Throw(string msg)
        {
            throw new PhpExceptions(msg);
        }
    }
}
