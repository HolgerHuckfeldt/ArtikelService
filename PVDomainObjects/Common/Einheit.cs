/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Torsten Gaul
 * Modul:    DomainObjects   
 * Funktionen: Kapselt die Informationen und Funktionen der ArtikelEinheit
 *************************************************************************/

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Common
{
    /// <summary>
    /// Einheiten wie: Stück, m, Kg und m
    /// </summary>
    [Serializable]

    public class Einheit : IEquatable<Einheit>, ISerializable
    {
        private string _Bezeichnung = string.Empty;

        public Einheit()
        {

        }

        public Einheit(SerializationInfo info, StreamingContext ctxt)
        {
            // Hier deserialisieren...

            var values = info.GetEnumerator();

            while (values.MoveNext())
            {

                switch (values.Name)
                {
                    case "Bezeichnung":
                        if (values.Value != null)
                            Bezeichnung = values.Value as string;
                        break;

                    case "Id":
                        if (values.Value != null)
                            Id = (Guid)values.Value;
                        break;

                    default:
                        Console.WriteLine("Unbekanntes Attribute:" + values.Name);
                        break;
                }
            }

        }



        public Guid Id
        {
            get;
            set;
        }

        public string Bezeichnung
        {
            get
            {
                return _Bezeichnung;
            }
            set
            {
                _Bezeichnung = value;
            }
        }


        #region IEquatable Member


        public bool Equals(Einheit other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            Einheit toCompare = obj as Einheit;
            if (toCompare != null)
                return toCompare.Id == Id;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region ISerializable Member

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bezeichnung", Bezeichnung);
            info.AddValue("Id", Id);
        }

        #endregion
    }
}