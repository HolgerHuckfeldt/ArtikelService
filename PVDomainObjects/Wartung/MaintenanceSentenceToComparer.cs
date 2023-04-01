using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Wartung.TransferObjects;

namespace PV.DomainObjects.Wartung
{
    public class MaintenanceSentenceToComparer : IEqualityComparer<MaintenanceSentenceTo>
    {
        // Products are equal if their names and product numbers are equal.
        public bool Equals(MaintenanceSentenceTo x, MaintenanceSentenceTo y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return true; //x.Kurztext == y.Kurztext;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(MaintenanceSentenceTo product)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(product, null)) return 0;

            //Get hash code for the Name field if it is not null.
            return 0; //product.Kurztext.GetHashCode();

        }

    }


}
