using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using System;

namespace BasicEcx.Controls.Fields.Date
{
    [ControlMarkupOptions(AllowContent = false)]
    public class FieldDateB : DotvvmMarkupControl
    {

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }
        public static readonly DotvvmProperty LabelTextProperty
            = DotvvmProperty.Register<string, FieldDateB>(c => c.LabelText, null);

        public DateTime? SelectedDate
        {
            get => (DateTime?)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }
        public static readonly DotvvmProperty SelectedDateProperty
            = DotvvmProperty.Register<DateTime?, FieldDateB>(c => c.SelectedDate, null);

        /// <summary>
        /// Gets or sets whether the control must have a value or not.
        /// <remarks>Default is false.</remarks>
        /// </summary>
        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }
        public static readonly DotvvmProperty IsRequiredProperty
            = DotvvmProperty.Register<bool, FieldDateB>(c => c.IsRequired, false);

        public string RequiredText
        {
            get => (string)GetValue(RequiredTextProperty);
            set => SetValue(RequiredTextProperty, value);
        }
        public static readonly DotvvmProperty RequiredTextProperty
            = DotvvmProperty.Register<string, FieldDateB>(c => c.RequiredText, null);



    }
}

