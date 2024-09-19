using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using GridViewColumn = DotVVM.BusinessPack.Controls.GridViewColumn;

namespace BasicEcx.Controls.Grid
{
    public class GridViewRowSelectColumn : DotVVM.BusinessPack.Controls.GridViewRowSelectColumn
    {
        public GridViewRowSelectColumn(BindingCompilationService bindingService) : base(bindingService)
        {
        }

        public override void BuildCol(HtmlGenericControl col)
        {
            if (IsPropertySet(GridViewColumn.VisibleProperty))
            {
                if ((bool)GetValue(GridViewColumn.VisibleProperty))
                    base.BuildCol(col);
            }
            else
            {
                base.BuildCol(col);
            }
        }
    }
}