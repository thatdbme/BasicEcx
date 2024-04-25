namespace BasicEcx.Models
{
    /// <summary>
    /// Represents a single button on the TitleBar.
    /// </summary>
    public class TitleBarButton
    {
        /// <summary>
        /// An ID value that can be used to identify what event to execute on the hosting page.
        /// </summary>
        /// <remarks>
        /// DevNote: The ID value must be unique within the page. Uniqueness is not enforced in any way.
        /// </remarks>
        public int EventCode { get; set; }

        /// <summary>
        /// The text to display for this item.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Indicates which button type this is.
        /// </summary>
        /// <remarks>
        /// Because the title bar separates the button types into individual lists
        /// and this value is included in the model sent to the client, we may not need to include this property.
        /// </remarks>
        public TitleBarButtonType Type { get; set; }

        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if clicking this button should bypass page validation.
        /// </summary>
        public bool SkipPageValidation { get; set; }

    }
}