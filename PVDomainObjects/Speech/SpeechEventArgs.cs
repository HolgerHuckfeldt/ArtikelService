using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Speech
{
    public class SpeechEventArgs : EventArgs
    {
        public string Result;
        public int Intention;
        public Guid Id;
    }
}
