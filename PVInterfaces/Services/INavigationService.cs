using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVInterfaces.Services
{
    /// <summary>
    /// Provides service methods for global navigation
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigates to the specified NavigationTarget
        /// </summary>
        /// <param name="target"></param>
        void NavigateTo(NavigationTarget target);

        /// <summary>
        /// Den AddOn-Reiter anzeigen. Name entspricht der id in der Addon.xml.
        /// </summary>
        /// <param name="name"></param>
        void NavigateAddOn(string name);

        /// <summary>
        /// Den AddOn-Reiter anzeigen. Name entspricht der id in der Addon.xml.
        /// Nach dem navigieren den link in dem AddOn navigieren.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="link"></param>
        void NavigateAddOn(string name, string link);
    }
}
