using PV.DomainObjects.Artikel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PVInterfaces.Services
{
    public interface IOlyslagerEmpfehlungsProvider : INotifyPropertyChanged
    {
        OelEmpfehlung OelEmpfehlungen { get; set; }
    }
}
