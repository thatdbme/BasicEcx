using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicEcx.Models
{
    /// <summary>
    /// The type of Action Button to add to the TitleBar.
    /// </summary>
    public enum TitleBarButtonType
    {
        /// <summary>
        /// An Action button for a page tab.
        /// </summary>
        TabAction,
        /// <summary>
        /// An Action button for a page.
        /// </summary>
        PageAction,
        /// <summary>
        /// An Action button that appears in the MoreActions menu.
        /// </summary>
        MoreActionsMenu
    }
}