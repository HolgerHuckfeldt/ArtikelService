using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Common
{
    [Serializable]
    [DataContract]
    public class ArbeitswertArt : IEquatable<ArbeitswertArt>, IComparable
    {

        #region Fields

        [DataMember]
        private Guid _id;

        [DataMember]
        private string _name;

        [DataMember]
        private int _prio;

        [DataMember]
        private double _EKStundenlohn;

        [DataMember]
        private double _VKStundenlohn;

        #endregion

        #region Properties

        [DataMember]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [DataMember]
        public int Prio
        {
            get
            {
                return _prio;
            }
            set
            {
                _prio = value;
            }
        }

        [DataMember]
        public string Tag
        {
            get;
            set;
        }

        public double EKStundenlohn
        {
            get
            {
                return _EKStundenlohn;
            }
            set
            {
                _EKStundenlohn = value;
            }
        }

        public double VKStundenlohn
        {
            get
            {
                return _VKStundenlohn;
            }
            set
            {
                _VKStundenlohn = value;
            }
        }

        #endregion

        public ArbeitswertArt()
        {

        }
        
        public ArbeitswertArt( Guid id )
        {
            Id = id;
        }

        #region Implementation of IEquatable<ArbeitswertArt>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals( ArbeitswertArt other )
        {
            return Id == other.Id;
        }

        public override bool Equals( object obj )
        {
            var toCompare = obj as ArbeitswertArt;

            if ( toCompare != null )
                return toCompare.Id == Id;

            return base.Equals( obj );
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        public int CompareTo(object obj)
        {
            if(obj is ArbeitswertArt)
            {
                var awArt = obj as ArbeitswertArt;

                return Name.CompareTo(awArt.Name);
            }

            throw new ArgumentException("Object ist keine ArbeitswertArt");
        }
    }
}
