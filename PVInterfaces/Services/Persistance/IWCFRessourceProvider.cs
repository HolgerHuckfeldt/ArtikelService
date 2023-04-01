using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


using System.Text;

namespace PVInterfaces.Services.Persistance
{
    
    public interface IWCFRessourceProvider
    {
   
        Stream GetRessource(Uri uri);
    }
}
