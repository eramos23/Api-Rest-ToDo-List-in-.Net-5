using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ApiExemtions : Exception
    {
        public ApiExemtions() : base() {}
        public ApiExemtions(string message): base(message){}
        public ApiExemtions(string message, params object[] arg) : base(string.Format(CultureInfo.CurrentCulture,message, arg))
        {
        }
    }
}
