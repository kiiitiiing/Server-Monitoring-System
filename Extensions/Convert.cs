using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Convert
    {
        public static int ToInt(this object obj)
        {
            int temp = 0;

            if (int.TryParse(obj.ToString(), out int result))
            {
                return result;
            }
            return temp;
        }

        public static IPAddress ToIpAddress(this object obj)
        {
            IPAddress temp = null;
            if (IPAddress.TryParse(obj.ToString(), out IPAddress result))
            {
                return result;
            }
            return temp;
        }
    }
}
