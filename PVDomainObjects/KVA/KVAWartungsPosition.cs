using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PV.DomainObjects.Wartung;

namespace PV.DomainObjects.KVA
{
    [Serializable]
    [KnownType(typeof(KVAPosition))]
    [KnownType(typeof(WartungsChecklisteItem))]
    //[KnownType(typeof(WartungsChecklisteItem[]))]
    [KnownType(typeof(List<WartungsChecklisteItem>))]
    public class KVAWartungsPosition 
    {

      
    }
}
