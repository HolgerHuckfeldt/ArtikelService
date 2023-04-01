using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PV.Persistance.Provider
{
    
    public interface ISpeechProvider
    {

        
        string Translate(byte[] indata, int intention);

    }
}
