using System;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Common
{
    [DataContract]
    [Serializable]
    public class Mandant
    {

        private static Mandant _Instance;
        private int _Id;

        private Mandant()
        {
            _Id = -1;
        }

        [DataMember]
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public static Mandant Instance
        {
            get
            {
                if ( _Instance == null )
                {
                    _Instance = new Mandant();

                }
                return _Instance;
            }
        }
    }
}

