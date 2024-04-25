using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicEcx.Common.Navigation
{
    public class NavPageViewModel
    {
        public NavPageViewModel()
        { }

        /// <summary>
        /// Creates an instance of NavPageViewModel with ResourceKey and URL specified.
        /// Optionally provides the fontAwesomeIconClass value.
        /// </summary>
        /// <param name="resourceKey">The associated ResourceKey.</param>
        /// <param name="url">The navigation URL.</param>
        /// <param name="fontAwesomeIconClass">The FontAwesome class string to use. Separate classes with a space. Example: "fas fa-plus fa-inverse"</param>
        public NavPageViewModel(string resourceKey, string url, string fontAwesomeIconClass = "")
        {
            Url = url;
            ResourceKey = resourceKey;
            CustomName = null;
            FontAwesomeIconClass = fontAwesomeIconClass;
        }

        /// <summary>
        /// Creates an instance of NavPageViewModel with ResourceKey, URL, and a CustomName specified.
        /// Optionally provides the fontAwesomeIconClass value.
        /// </summary>
        /// <param name="resourceKey">The associated ResourceKey.</param>
        /// <param name="url">The navigation URL.</param>
        /// <param name="customName">The CustomName string value for the link.</param>
        /// <param name="fontAwesomeIconClass">The FontAwesome class string to use. Separate classes with a space. Example: "fas fa-plus fa-inverse"</param>
        public NavPageViewModel(string resourceKey, string url, string customName, string fontAwesomeIconClass = "")
        {
            Url = url;
            ResourceKey = resourceKey;
            CustomName = customName;
            FontAwesomeIconClass = fontAwesomeIconClass;
        }

        public string Url { get; set; }

        public string CustomName { get; set; }

        public string ResourceKey { get; set; }

        /// <summary>
        /// The FontAwesome class string to use. Separate classes with a space.
        /// </summary>
        /// <example>fas fa-plus fa-inverse</example>
        public string FontAwesomeIconClass { get; set; }
    }
}