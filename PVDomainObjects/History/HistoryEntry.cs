/****************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeug-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines allgemeinen Historyeintrages
 ****************************************************************************************/

using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows;


namespace PV.DomainObjects.History
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen eines allgemeinen Historyeintrages
    /// </summary>
    [Serializable]
    [DataContract]
    public class HistoryEntry
    {
        #region Fields

        private bool _Dirty;
        private Guid _Id;
        private string _DisplayString;
        private Guid _User;
        private DateTime _LastUse;
        private string _RessourceUri;
        
        #endregion

        #region Properties

        [DataMember]
        public string DisplayString
        {
            get
            {
                return _DisplayString;
            }
            set
            {
                _DisplayString = value;
            }
        }

        [DataMember]
        public Guid User
        {
            get { return _User; }
            set { _User = value; }
        }

        [DataMember]
        public DateTime LastUse
        {
            get { return _LastUse; }
            set { _LastUse = value; }
        }

        [DataMember]
        public string RessourceUri
        {
            get { return _RessourceUri; }
            set { _RessourceUri = value; }
        }

        [DataMember]
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        [DataMember]
        public bool Dirty
        {
            get { return _Dirty; }
            set { _Dirty = value; }
        }


        #endregion

        #region Konstruktoren

        public HistoryEntry()
        {
        }

        public HistoryEntry(Guid _user, string _disString, string _resUri)
        {
            Dirty = true;
            User = _user;
            DisplayString = _disString;
            LastUse = DateTime.Now;
            RessourceUri = _resUri;
        }

        #endregion

        public override string ToString()
        {
            return DisplayString;
        }
    }
}
