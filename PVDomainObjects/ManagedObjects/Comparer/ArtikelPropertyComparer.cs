/********************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz/Walter Licht
 * Modul:    ArtikelIdent
 * Funktionen:  
 ********************************************************************************************************/

using System;
using System.Reflection;

namespace PV.DomainObjects.ManagedObjects
{
    [Serializable]
    public class ArtikelPropertyComparer : ArtikelComparerBase
    {
        private PropertyInfo _Property;
        private Boolean _negate;

        public ArtikelPropertyComparer()
        {
            SetPropertyForSort("");
        }

        public override PropertyInfo GetPropertyForSort()
        {
            return _Property;
        }

        public void SetPropertyForSort_OhneProcessStrategies(String _property)
        {
            PropertyInfo propertyInfo = typeof(Artikel.Artikel).GetProperty(_property);
            if (propertyInfo != null && propertyInfo.CanRead)
            {
                if (_Property == propertyInfo)
                {
                    _negate = !_negate;
                }
                else
                {
                    _negate = false;
                    _Property = propertyInfo;
                }
            }
            else if (propertyInfo == null)
                _Property = null;
        }

        public void SetPropertyForSort(String _property)
        {
            PropertyInfo propertyInfo = typeof(Artikel.Artikel).GetProperty(_property);
            if (propertyInfo != null && propertyInfo.CanRead)
            {
                if (_Property == propertyInfo)
                {
                    _negate = !_negate;
                }
                else
                {
                    _negate = false;
                    _Property = propertyInfo;
                }
            }
            else
            {
                _Property = null;
            }

            //ProcessStrategies aus Basisklasse aufrufen
            ProcessStrategies();
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// Value 
        ///                     Condition 
        ///                     Less than zero
        ///                 <paramref name="x"/> is less than <paramref name="y"/>.
        ///                     Zero
        ///                 <paramref name="x"/> equals <paramref name="y"/>.
        ///                     Greater than zero
        ///                 <paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <param name="x">The first object to compare.
        ///                 </param><param name="y">The second object to compare.
        ///                 </param>
        public override int Compare( Artikel.Artikel x, Artikel.Artikel y )
        {
            if ( _Property == null )
                    return 0;

                Object a = _Property.GetValue( x, null );
                Object b = _Property.GetValue( y, null );

                MethodInfo m = a.GetType().GetMethod( "CompareTo", new[] { a.GetType() } );


                if ( m != null )
                {
                    return ((Int32) m.Invoke(a, new[] {b}))*(_negate ? (-1) : 1);
                }
                return 0;
        }

    }
}
