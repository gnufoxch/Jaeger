using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ValidationException:Exception
    {
        public ValidationException(string message):base(message){}
    }
}
