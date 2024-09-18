using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using static BasicEcx.Content.Admin.Configuration.TimeSheetPeriodViewModel;
using BasicEcx.Common.Navigation;

namespace BasicEcx.Content.Errors
{
    public class PageNotFoundViewModel : _ErrorsViewModel
    {

        #region Override Methods

        protected override void InitializeView()
        {
            SetupTitleBar();

            //Frequency.IsRequired = true;

            base.InitializeView();
        }

        #endregion Override Methods

        #region Private Methods

        /// <summary>
        /// Sets up the TitleBar. Includes the page title,
        ///     Nav Links, Tab Action buttons, Page Action buttons, and More Actions menu items.
        /// </summary>
        private void SetupTitleBar()
        {
            // Lines that are only needed on first load
            if (Context.IsPostBack)
                return;

            SetPageTitle("You have requested a URL that does not exist");
        }


        #endregion Private Methods

    }
}

