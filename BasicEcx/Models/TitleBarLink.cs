using DotVVM.Framework.ViewModel;

namespace BasicEcx.Models
{
    /// <summary>
    /// Represents a navigation link in the TitleBar.
    /// </summary>
    public class TitleBarLink
    {
        /// <summary>
        /// The text to display for this link.
        /// </summary>
        public string Text { get; set; }

        [Bind(Direction.None)]
        public string ResourceKey { get; set; }
        /// <summary>
        /// The URL to navigate to when this link is clicked.
        /// </summary>
        public string Url { get; set; }

        [Bind(Direction.None)]
        public bool DefaultView { get; set; }

        [Bind(Direction.None)]
        public bool IsActive { get; set; }

        /// <summary>
        /// The full CSS class string to apply to this link.
        /// </summary>
        public string CssClass { get; set; }
    }
}