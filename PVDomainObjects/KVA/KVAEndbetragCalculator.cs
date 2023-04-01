using System;
using System.ComponentModel;
using System.Diagnostics;

namespace PV.DomainObjects.KVA
{
    [Serializable]
    public class KVAEndbetragCalculator : INotifyPropertyChanged
    {
        public KVAPosition _Position;

        public KVAEndbetragCalculator( decimal ekOriginal, decimal vkOriginal )
        {
            StackTrace st = new StackTrace();



            VKOriginal = vkOriginal;
        }

        void _Position_PropertyChanged( object sender, PropertyChangedEventArgs e )
        {
            NotifyPropertyChanged( e.PropertyName );
            NotifyPropertyChanged( "BruttoPreisEinzel" );
        }

        private decimal VKOriginal
        {
            get;
            set;
        }

        public decimal VolleSteuerOriginal
        {
            get;
            set;
        }

        private decimal VolleSteuerRabattiert
        {
            get
            {
                return VolleSteuerOriginal ;
            }
        }


        public decimal ErmaessigteSteuerOriginal
        {
            get;
            set;
        }

        private decimal ErmässigteSteuerRabattiert
        {
            get
            {
                return ErmaessigteSteuerOriginal ;
            }
        }


        public decimal AltteileSteuerOriginal
        {
            get;
            set;
        }

        private decimal AltteileSteuerRabattiert
        {
            get
            {
                return AltteileSteuerOriginal;
            }
        }


        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged( string propertyName )
        {
            if ( PropertyChanged != null )
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
        }

        #endregion
    }
}
