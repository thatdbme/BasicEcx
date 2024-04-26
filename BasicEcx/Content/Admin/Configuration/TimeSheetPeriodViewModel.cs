using BasicEcx.BusinessObjects;
using BasicEcx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BasicEcx.Content.Admin.Configuration
{
    public class TimeSheetPeriodViewModel : BasicEcx.Content.Admin._AdminViewModel
    {
        #region Fields & Constants

        private FakeController _controller;
        //private FakePresenter _presenter;

        private const int BUTTON_EVENT_CODE_CANCEL = 1;
        private const int BUTTON_EVENT_CODE_SUBMIT = 2;

        #endregion Fields & Constants

        #region Override Methods

        protected override void InitializeContext()
        {
            _controller = new FakeController(); //ControllerFactory.GetController<IToolController>(UserContextDatabase);
            //_presenter = PresenterFactory.GetPresenter<IToolPresenter>(UserAccess);

            base.InitializeContext();
        }
        
        protected override void InitializeView()
        {
            SetupTitleBar();

            //Frequency.IsRequired = true;

            base.InitializeView();
        }

        #endregion Override Methods

        #region Page Lifecycle Methods

        public TimeSheetPeriodViewModel() {}

        public override Task Load()
        {

            TitleBar.TabActionButtonClicked += TitleBar_TabActionButtonClicked;

            if (!Context.IsPostBack)
            {
                var viewModel = _controller.GetTimeSheetPeriod(true);
                MapViewModelToPage(viewModel);
            }

            return base.Load();
        }

        #endregion Page Lifecycle Methods

        #region Event Handlers

        /// <summary>
        /// Passes the click event of the Submit or Cancel buttons to the appropriate action handler.
        /// </summary>
        /// <param name="sender">The button that was clicked.</param>
        private void TitleBar_TabActionButtonClicked(TitleBarButton sender)
        {
            // Call the appropriate handler.
            switch (sender.EventCode)
            {
                case BUTTON_EVENT_CODE_SUBMIT:
                    ActionSubmit();
                    break;
                case BUTTON_EVENT_CODE_CANCEL:
                    ActionCancel();
                    break;
            }
        }

        #endregion Event Handlers

        #region Action Handlers

        /// <summary>
        /// Cancel the action and redirect to the ToolList page.
        /// </summary>
        protected void ActionCancel()
        {
            var url = "/"; //Navigation.Tool.ToolList();

            Context.RedirectToLocalUrl(url); //NavigationHelper.NavigateToDvm(Context, url);
        }

        /// <summary>
        /// Save the data and redirect to the ToolList page.
        /// </summary>
        protected void ActionSubmit()
        {
            var viewModel = MapPageToViewModel();

            if (viewModel == null)
                return;

            _controller.CreateTimesheetPeriod(viewModel);

            // ToDo: use the messagebox to show success message
            //NavigationHelper.NavigateToWithMessageDvm(Context, Navigation.Tool.ToolList(),
            //    ToolResourcing.TimesheetPeriodCreatedMessage);
        }

        #endregion Action Handlers

        #region Private Methods

        private static List<MenuItem> MapDictionaryToMenuItems(Dictionary<string, string> input)
        {
            return input.Keys.Select(key => new MenuItem()
            {
                Text = input[key],
                Value = key
            }).ToList();
        }

        /// <summary>
        /// Map the page properties to a <see cref="TimeSheetPeriodModel"/>.
        /// </summary>
        private TimeSheetPeriodModel MapPageToViewModel()
        {
            var model = new TimeSheetPeriodModel
            {
                //EndDate = EndDate.SelectedDate.Value,
                //StartDate = StartDate.SelectedDate.Value,

                //TimeSheetCycleId = Convert.ToInt32(Cycle.SelectedValue),
                //TimeSheetFrequencyId = Convert.ToInt32(Frequency.SelectedValue)
            };

            return model;
        }

        /// <summary>
        /// Map the retrieved <see cref="TimeSheetPeriodModel"/> to the local viewmodel.
        /// </summary>
        /// <param name="viewModel">The viewmodel retrieved from the DB.</param>
        private void MapViewModelToPage(TimeSheetPeriodModel viewModel)
        {
            //StartDate.SelectedDate = viewModel.StartDate;
            //EndDate.SelectedDate = viewModel.EndDate;

            //Frequency.DataSource = MapDictionaryToMenuItems(viewModel.TimeSheetFrequencyList);
            //Frequency.SelectedValue = viewModel.TimeSheetFrequencyId.ToString();

            //Cycle.DataSource = MapDictionaryToMenuItems(viewModel.TimeSheetCycleList);
            
            //Cycle.SelectedValue = Cycle.DataSource.FirstOrDefault()?.Value;
        }

        /// <summary>
        /// Sets up the TitleBar. Includes the page title,
        ///     Nav Links, Tab Action buttons, Page Action buttons, and More Actions menu items.
        /// </summary>
        private void SetupTitleBar()
        {
            // Lines that are needed on every page load
            TitleBar.AddTabActionButton("Submit", BUTTON_EVENT_CODE_SUBMIT);
            TitleBar.AddTabActionButton("Cancel", BUTTON_EVENT_CODE_CANCEL, true);


            // Lines that are only needed on first load
            if (Context.IsPostBack)
                return;

            SetPageTitle("Create Timesheet Period");
        }

        #endregion Private Methods
    }

    #region Fake Helper objects


    public class FakeController
    {
        public void CreateTimesheetPeriod(TimeSheetPeriodModel dummy){}

        public TimeSheetPeriodModel GetTimeSheetPeriod(bool dummy)
        {
            var model = new TimeSheetPeriodModel
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                TimeSheetFrequencyId = Constants.TimeSheetFrequency.WEEKLY,
                TimeSheetCycleList = new Dictionary<string, string>
                {
                    { "1", "Week Ending - Sunday" },
                    { "4", "Week Ending - Thursday" },
                    { "7", "Week Ending - Monday" }
                },
                TimeSheetFrequencyList = new Dictionary<string, string>
                {
                    { "3", "Bi-Weekly" },
                    { "2", "Monthly" },
                    { "4", "Semi-Monthly" },
                    { "1", "Weekly" }
                }
            };

            return model;
        }
    }


    #endregion Fake Helper objects

}