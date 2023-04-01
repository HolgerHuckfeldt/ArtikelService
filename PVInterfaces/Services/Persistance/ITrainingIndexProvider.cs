using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.LMS;


namespace PV.Persistance.Provider
{
    
    
    public interface ITrainingIndexProvider
    {
        
        List<TrainingSuchErgebniss> SearchByString(string toSerach, int training);

    }
}
