using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Exceptions
{
    [Serializable]
    public class VdbException : ApplicationException
    {
        public VdbException()
        {
        }
        public VdbException(string message):base(message) { }
        public VdbException(string message, Exception inner) 
                                  :base(message, inner) { } 
    }
}
