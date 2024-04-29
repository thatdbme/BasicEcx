using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicEcx.Controls.Fields.Date.Model
{
    /// <summary>
    /// The viewmodel for a date selection field.
    /// </summary>
    /// <remarks>
    /// DevNote: The control is intended to be used as a child of a div with the "container-fluid" class.
    /// </remarks>
    public class FieldDateViewModel : FieldControlViewModelBase
    {
        /*  ToDo DVM: Possible needs for the FieldDate control:
         *  1) test with multiple languages and cultures
         *  2) make any needed CSS changes
         *  3) expose week numbers (do we use that anywhere?)
         *  4) expose/allow limited date ranges
         */

        #region Control Propeties
        
        private DateTime? _selectedDate;
        /// <summary>
        /// Gets or sets the user selected date value, at midnight.
        /// </summary>
        public DateTime? SelectedDate
        {
            get => _selectedDate?.Date ?? _selectedDate;
            set => _selectedDate = value;
        }
        
        #endregion Control Propeties

        #region Constructors

        /// <summary>
        /// Creates a new empty FieldDateViewModel.
        /// </summary>
        public FieldDateViewModel() { }

        /// <summary>
        /// Creates a new FieldDateViewModel instance with the LabelText value set.
        /// </summary>
        /// <param name="labelText">A string representing the clear text label value for the field.</param>
        /// <param name="isRequired">A boolean value indicating if the field value is required. Defaults to false.</param>
        public FieldDateViewModel(string labelText, bool isRequired = false)
        {
            LabelText = labelText;
            IsRequired = isRequired;
        }

        /// <summary>
        /// Creates a new FieldDateViewModel instance with the LabelText and SelectedDate values set.
        /// </summary>
        /// <param name="labelText">A string representing the clear text label value for the field.</param>
        /// <param name="selectedDate">The initial date to set for the DateField value.</param>
        /// <param name="isRequired">A boolean value indicating if the field value is required. Defaults to false.</param>
        public FieldDateViewModel(string labelText, DateTime? selectedDate, bool isRequired = false)
        {
            LabelText = labelText;
            SelectedDate = selectedDate;
            IsRequired = isRequired;
        }

        #endregion Constructors

        #region Lifecycle Methods

        //public override Task Load()
        //{

        //    return base.Load();
        //}

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsRequired && SelectedDate == null)
            {
                yield return new ValidationResult(
                    "Required",
                    new[] { nameof(SelectedDate) }
                );
            }
        }

        #endregion Lifecycle Methods

        #region Private Methods

        

        #endregion Private Methods
    }
}
