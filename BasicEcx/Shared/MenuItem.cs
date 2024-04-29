using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicEcx.Shared
{
    /// <summary>
    /// Represents a single item in a menu.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// The text to be displayed for the menu item.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The value assigned to this menu item.
        /// For example, it could be a URL or a drop-down list value.
        /// </summary>
        public string Value { get; set; }

    }
}