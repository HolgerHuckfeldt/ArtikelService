using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Werkstatt
{
    [Serializable]
    [DataContract]
    public class TrainingsCardMitarbeiter
    {
        #region Properties

        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Anrede
        {
            get;
            set;
        }

        [DataMember]
        public string Vorname
        {
            get;
            set;
        }

        [DataMember]
        public string Nachname
        {
            get;
            set;
        }

        [DataMember]
        public string Position
        {
            get;
            set;
        }

        #endregion

        #region UI-Properties

        public List<string> AnredeList
        {
            get;
            set;
        }

        public List<string> PositionList
        {
            get;
            set;
        }

        #endregion
    }
}
