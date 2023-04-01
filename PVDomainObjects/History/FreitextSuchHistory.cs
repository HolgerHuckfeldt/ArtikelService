using System;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace PV.DomainObjects.History
{

    /// <summary>
    /// Representiert die unterschiedlichen Suchen, welche ein User in einem Freitextsuchfeld abgeschickt hat
    /// </summary>
    [Serializable]
    [DataContract]
    public class FreitextSuchHistory
    {

        #region Props

        /// <summary>
        /// Liefert und setzt die Id in der Datenbasis
        /// </summary>
        [DataMember]
        public Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information in welcher Freitextsuche der String verwendet wurde
        /// </summary>
        [DataMember]
        public FreitextSucharten Suchart
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den String nach dem gesucht wurde
        /// </summary>
        [DataMember]
        public string SuchString
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information, wann zuletzt nach diesem String gesucht wurde
        /// </summary>
        [DataMember]
        public DateTime LastUse
        {
            get;
            set;
        }

        private bool _dirty = false;

        /// <summary>
        /// Liefert und setzt die Information, ob das Entry gesichert werden muss
        /// </summary>
        [DataMember]
        public bool Dirty
        {
            get { return _dirty; }
            set { _dirty = value; }
        }

        /// <summary>
        /// Liefert und setzt die ID des Users
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get;
            set;
        }

        #endregion
    }
}
