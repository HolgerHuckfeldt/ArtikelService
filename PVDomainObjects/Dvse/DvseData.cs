using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PV.DomainObjects.Dvse
{
    public class DvseData
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string FieldEuroTaxKT = string.Empty;

        private static string FieldEuroTaxAuth = string.Empty;

        public HashSet<int> DvseKTypes = new HashSet<int>();
        public bool KTypesSet = false;

        public decimal DvseKkz { get; set; }
        public decimal DvseVKkz { get; set; }

        public CustomAction DvseExtern;
        private string _dvseUrl;
        public CustomAction DvseIntern;
        public bool IsDvseVirtual = false;

        private decimal AuthActive = 0;
        private decimal AuthPassive = 0;


        public Stammdaten.Profil Profile
        {
            get; set;
        }

        public void SetKTypes(List<int> ktypes)
        {
            if (ktypes != null)
                foreach (var ktype in ktypes)
                {
                    DvseKTypes.Add(ktype);
                }
            KTypesSet = true;
        }

        //public string EurotaxKType
        //{
        //    get
        //    {
        //        return FieldEuroTaxKT;
        //    }
        //    set
        //    {
        //        FieldEuroTaxKT = value;
        //        try
        //        {
        //            var parts = FieldEuroTaxKT.Split(';');

        //            int ival = 0;
        //            foreach (var part in parts)
        //            {
        //                if (int.TryParse(part, out ival))
        //                {
        //                    DvseKTypes.Add(ival);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Error(ex);
        //        }
        //    }
        //}

        public string EurotaxAuth
        {
            get
            {
                return FieldEuroTaxAuth;
            }
            set
            {
                FieldEuroTaxAuth = value;

                XDocument xdoc = XDocument.Parse(FieldEuroTaxAuth);
                var root = xdoc.Root;

                if (root != null)
                {
                    var addOn = root.Element("AddOns");

                    foreach (var addOnItem in addOn.Elements("AddOn"))
                    {

                        string name = string.Empty;


                        //decimal AuthActive = 0;
                        //decimal AuthPassive = 0;

                        // Name
                        var nameElement = addOnItem.Element("Name");
                        if (nameElement != null)
                            name = nameElement.Value;
                        // Bilderchen

                        if (DvseExtern == null)
                            DvseExtern = new CustomAction();

                        DvseExtern.Load(addOnItem.Element("ActionExtern"));
                        //_dvseIntern.Load(addOnItem.Element("ActionIntern"));
                        _dvseUrl = DvseExtern.Url;

                        if (DvseIntern == null)
                            DvseIntern = new CustomAction();

                        DvseIntern.Load(addOnItem.Element("ActionIntern"));
                        //_dvseIntern.Load(addOnItem.Element("ActionIntern"));
                        _dvseUrl = DvseExtern.Url;

                        // Authentification
                        var authElement = addOnItem.Element("Authentification");
                        if (authElement != null)
                        {
                            string sVal = authElement.Attribute("kkz").Value;
                            decimal.TryParse(sVal, out AuthActive);
                            sVal = authElement.Attribute("vkkz").Value;
                            decimal.TryParse(sVal, out AuthPassive);

                            // Darf ich und wenn ja, welche?
                            //var profile = Managers.Werkstattmanager.CurrentWerkstatt.ActiveProfiles.FirstOrDefault();
                            if (Profile != null)
                            {
                                var kkzRaw = Profile.KonzeptkennzeichenRaw;

                                if (kkzRaw.Contains(AuthActive))
                                {
                                    DvseKkz = AuthActive;
                                    IsDvseVirtual = false;
                                }
                                else
                                {
                                    if (kkzRaw.Contains(AuthPassive))
                                    {
                                        DvseVKkz = AuthPassive;
                                        IsDvseVirtual = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ReCheck()
        {
            if (Profile != null)
            {
                var kkzRaw = Profile.KonzeptkennzeichenRaw;

                if (kkzRaw.Contains(AuthActive))
                {
                    DvseKkz = AuthActive;
                    IsDvseVirtual = false;
                }
                else
                {
                    if (kkzRaw.Contains(AuthPassive))
                    {
                        DvseVKkz = AuthPassive;
                        IsDvseVirtual = true;
                    }
                }
            }
        }

        public string DvseUrl
        {
            get { return _dvseUrl; }

        }

    }
}
