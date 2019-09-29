using System;
using System.Collections.Generic;
using System.Text;

namespace OrderGenerator
{
    public static class Status
    {
        private static bool _waarde = false;

        public static bool GetBoolValue()
        {
            _waarde = !_waarde;
            return _waarde;
        }
    }
}
