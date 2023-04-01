/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Torsten Gaul
 * Modul:    DomainObjects   
 * Funktionen: Kapselt die Informationen und Funktionen der Ressource
 *************************************************************************/

using System;

namespace PV.DomainObjects.Kunden
{
    [Serializable]
    public class Ressource
    {
        #region fields

        private Guid _Id;
        private string _DisplayString;
        private Uri _Uri;

        #endregion

        #region Props

        public Guid Id
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

        public Uri Uri
        {
            get
            {
                return _Uri;
            }
            set
            {
                _Uri = value;
            }
        }

        #endregion

        #region constructors

        public Ressource()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
