using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotVVM.Framework.ViewModel;

namespace BasicEcx.Controls.Fields
{
    /// <summary>
    /// A base viewmodel for all custom DotVVM Field controls.
    /// </summary>
    /// <remarks>Defines common properties for all controls: LabelText, IsRequired.</remarks>
    public class FieldControlViewModelBase : DotvvmViewModelBase, IField
    {
        public bool IsRequired { get; set; }

        [Bind(Direction.None)]
        public string LabelText { get; set; }
        
        /// <summary>
        /// The text to display for the word "Required". The value comes from the PageResourcing.Required resource key.
        /// </summary>
        [Bind(Direction.None)]
        public string RequiredText { get; set; } = "Required";


        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            /* The Validate method must be implemented as an override in the inheriting control. */
            throw new NotImplementedException("Please implement a local override of the Validate method.");
        }
    }
}
