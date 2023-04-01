using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class NodeIdGenArt
    {
        [DataMember]
        public Int32 GenArtId
        {
            get;
            set;
        }

        [DataMember]
        public Int32 ParentNodeId
        {
            get;
            set;
        }
    }
}
