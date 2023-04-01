using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace PV.DomainObjects.Dvse
{
    public class CustomAction
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Url
        {
            get;
            set;
        }

        public string Method
        {
            get;
            set;
        }

        public string UrlKType
        {
            get;
            set;
        }

        public string UrlPassive
        {
            get;
            set;
        }

        public bool Single
        {
            get;
            set;
        }

        public bool Redirect
        {
            get;
            set;
        }

        // <ActionExtern active="http://www.absolute.de" activeKt="http://www.absolute.de?ktype=$KTYPE$" passive="http://www.otto.de" mode="single" action="redirect"/>
        public void Load(XElement element)
        {
            try
            {
                if (element != null)
                {
                    if (element.HasAttributes)
                    {
                        if (element.Attribute("active") != null)
                            Url = element.Attribute("active").Value;

                        if (element.Attribute("activeKt") != null)
                            UrlKType = element.Attribute("activeKt").Value;

                        if (element.Attribute("passive") != null)
                            UrlPassive = element.Attribute("passive").Value;

                        if (element.Attribute("mode") != null)
                            Single = element.Attribute("mode").Value.ToLower() == "single";

                        if (element.Attribute("action") != null)
                            Redirect = element.Attribute("action").Value.ToLower() == "redirect";

                        if (element.Attribute("method") != null)
                            Method = element.Attribute("method").Value;
                        else
                            Method = string.Empty;
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(string.Format("Error bei {0}", MethodInfo.GetCurrentMethod().Name), ex);
            }
        }

    }
}
