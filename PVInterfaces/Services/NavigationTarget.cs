using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PVInterfaces.Services
{
    /// <summary>
    /// Represents a navigation target in the global navigation structure
    /// </summary>
    public partial class NavigationTarget
    {
        public interface INavigationStep
        {
        }

        public class TabNavigation : INavigationStep
        {
            public string TabControlName { get; set; }
            public string TabItemName { get; set; }

            public TabNavigation(string tabControlName, string tabItemName)
            {
                TabControlName = tabControlName;
                TabItemName = tabItemName;
            }
        }

        public class ControlNavigation : INavigationStep
        {
            public string ControlName
            {
                get; set;
            }

            public ControlNavigation(string controlName)
            {
                ControlName = controlName;
            }
        }

        private readonly IList<INavigationStep> _navigationList = new List<INavigationStep>();

        /// <summary>
        /// The ordered list of navigation steps to be made, in order to navigate to the target
        /// </summary>
        public IList<INavigationStep> NavigationList
        {
            get
            {
                return _navigationList;
            }
        }

        /// <summary>
        /// Adds a TabNavigation step to the navigation path
        /// </summary>
        /// <param name="tabControlName"></param>
        /// <param name="tabPageName"></param>
        /// <returns></returns>
        public NavigationTarget AddTabNavigation(string tabControlName, string tabPageName)
        {
            _navigationList.Add(new TabNavigation(tabControlName, tabPageName));
            return this;
        }

        public NavigationTarget AddControlNavigation(string controlName)
        {
            _navigationList.Add(new ControlNavigation(controlName));
            return this;
        }
    }
}
