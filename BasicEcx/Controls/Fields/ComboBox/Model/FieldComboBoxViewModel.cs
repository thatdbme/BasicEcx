using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BasicEcx.Shared;
using DotVVM.Framework.ViewModel;

namespace BasicEcx.Controls.Fields.ComboBox.Model
{
    /// <summary>
    /// The viewmodel for a combobox field.
    /// </summary>
    /// <remarks>
    /// DevNote: The control is intended to be used as a child of a div with the "container-fluid" class.
    /// </remarks>
    public class FieldComboBoxViewModel : FieldControlViewModelBase
    {
        #region Control Propeties

        /// <summary>
        /// Gets or sets a value indicating if the user is allowed to clear the selected value from the combobox.
        /// </summary>
        /// <remarks>Default value is false.</remarks>
        [Bind(Direction.None)]
        public bool AllowUnselect { get; set; }
        
        /// <summary>
        /// Gets or sets the source of the data for the combobox.
        /// </summary>
        public List<MenuItem> DataSource { get; set; }

        /// <summary>
        /// Gets or sets the value to use as the placeholder text
        /// when no value has been selected by the user.
        /// </summary>
        /// <remarks>
        /// If IsRequired is true but no PlaceholderText value is provided,
        /// the default Required value will be used.
        /// </remarks>
        [Bind(Direction.None)]
        public string PlaceholderText { get; set; }
        
        /// <summary>
        /// Gets or sets the value selected in the combobox.
        /// </summary>
        public string SelectedValue { get; set; }

        #endregion Control Propeties

        #region Constructors

        /// <summary>
        /// Creates a new empty FieldComboBoxViewModel.
        /// </summary>
        public FieldComboBoxViewModel() { }

        /// <summary>
        /// Creates a new FieldComboBoxViewModel instance with the LabelText value set.
        /// </summary>
        /// <param name="labelText">A string representing the clear text label value.</param>
        /// <param name="isRequired">A boolean value indicating if the field value is required. Defaults to false.</param>
        public FieldComboBoxViewModel(string labelText, bool isRequired = false)
        {
            LabelText = labelText;
            IsRequired = isRequired;
        }

        #endregion Constructors

        #region Lifecycle Methods

        public override Task Load()
        {
            CheckPlaceholderText();

            return base.Load();
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsRequired && string.IsNullOrEmpty(SelectedValue))
            {
                yield return new ValidationResult(
                    "Required",
                    new[] { nameof(SelectedValue) }
                );
            }
        }

        #endregion Lifecycle Methods

        #region Private Methods

        /// <summary>
        /// Checks the PlaceholderText and IsRequired property values.
        /// If IsRequired is true but no PlaceholderText value was provided,
        /// the default Required value will be used.
        /// </summary>
        private void CheckPlaceholderText()
        {
            if (string.IsNullOrEmpty(PlaceholderText) && (IsRequired))
                PlaceholderText = "Required";
        }

        #endregion Private Methods
    }
}
