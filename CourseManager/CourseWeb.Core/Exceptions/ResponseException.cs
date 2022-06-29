using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWeb.Core.Exceptions
{
   public  class ResponseException:Exception
    {
        public ResponseException(object value = null) => (Value) = (value);
        public object Value { get; }
    }
}
