using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.Controller
{
    public  class Instance <T>
    {
        public string Message { get; set; }
        public T obj { get; set; }

        public Instance(string message, T obj)
        {
            Message = message;
            this.obj = obj;
        }
        public Instance()
        {
            Message = null;
   
        }
    }
}
