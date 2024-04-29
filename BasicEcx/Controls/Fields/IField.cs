using System.ComponentModel.DataAnnotations;

namespace BasicEcx.Controls.Fields
{
    /// <summary>
    /// A base interface for all custom DotVVM Field controls.
    /// </summary>
    /// <remarks>Defines common properties for all controls: LabelText, IsRequired.</remarks>
    public interface IField :  IValidatableObject
    {
        /// <summary>
        /// Gets or sets the string that will be used as the label text for the field.
        /// </summary>
        string LabelText { get; set; }


        /// <summary>
        /// Gets or sets a value indicating if the field must have a value.
        /// </summary>
        bool IsRequired { get; set; }
    }
}
