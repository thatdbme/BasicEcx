using BasicEcx.Controls.Page;
using DotVVM.Framework.ViewModel;
using System.Threading.Tasks;

namespace BasicEcx.MasterPages
{
    public class LayoutViewModel : DotvvmViewModelBase
    {
        #region Public Properties Not Part of the Viewmodel

        ///// <summary>
        ///// Gets a value indicating if the MessageBox will be included in the page.
        ///// If <see cref="MessageBox"/> is null, false is returned.
        ///// </summary>
        ///// <remarks>
        ///// DevNote: The value is determined by the MessageBoxViewModel.ShowMessageBox.
        ///// </remarks>
        //[Bind(Direction.ServerToClient)]
        //public bool ShowMessageBox => GetShowMessageBoxValue();

        /// <summary>
        /// The UserId of the logged-in user.
        /// </summary>
        [Bind(Direction.None)]
        public int UserId => 123456;

        #endregion Public Properties Not Part of the Viewmodel

        #region ViewModel Properties

        ///// <summary>
        ///// The MessageBox control.
        ///// </summary>
        //public MessageBoxViewModel MessageBox { get; set; }

        /// <summary>
        /// The title of the page.
        /// Set the value using the SetPageTitle() method.
        /// </summary>
        /// <remarks>Can be overriden by any page.</remarks>
        [Bind(Direction.None)]
        public string PageTitle { get; private set; }

        /// <summary>
        /// The TitleBar control.
        /// </summary>
        [Bind()]
        public TitleBarViewModel TitleBar { get; set; }

        /// <summary>
        /// Fake object that does nothing.
        /// It can be used as the target for validation or anything else that needs an object but doesn't need to do anything.
        /// </summary>
        public object Decoy { get; set; } = new object();

        #endregion ViewModel Properties

        #region Page Lifecycle Methods

        protected LayoutViewModel()
        {
            TitleBar = new TitleBarViewModel();
            //MessageBox = new MessageBoxViewModel();
        }

        /// <summary>
        /// Occurs 2nd, after the viewmodel's constructor.
        /// </summary>
        /// <remarks>
        /// DevNote: Context is available now.
        /// </remarks>
        public override Task Init()
        {/* Occurs second */

            //// If the user is not logged in to ECX, redirect to the login page.
            //if (UserId <= 0)
            //{
            //    /*  Expected error:
            //     *      "DotVVM.Framework.Hosting.DotvvmInterruptRequestExecutionException: 'Request interrupted: Redirect (~/Login.aspx")
            //     *  Do nothing with it and let it continue. DotVVM needs it to work correctly.
            //     *  See this DotVVM blog post for more details and to learn how to make Visual Studio not stop on this exception:
            //     *      https://www.dotvvm.com/blog/1/Why-I-am-getting-the-DotvvmInterruptRequestExecutionException
            //     */

            //    Context.RedirectToLocalUrl("~/Login.aspx");
            //}

            InitializeContext();
            InitializePageSecurity();

            return base.Init();
        }

        /// <summary>
        /// Occurs 3rd, after Init()
        /// </summary>
        public override Task Load()
        {/* Occurs third */
            
            InitializeView();

            //ShowOneTimeMessageIfNeeded();

            return base.Load();
        }

        /* Command-invoked methods occur next */

        /// <summary>
        /// Occurs 4th, after Load() AND after command-invoked methods.
        /// </summary>
        public override Task PreRender()
        {/* Occurs fourth (after command-invoked methods) */
            
            return base.PreRender();
        }

        #endregion Page Lifecycle Methods

        #region Virtual Methods

        /// <summary>
        /// Set up the context items for the page.
        /// Called by LayoutViewModel.Init() method.
        /// </summary>
        /// <remarks>
        /// DevNote: Set up Presenters needed only by one page in that page's InitializeContext method.
        /// Presenters shared by multiple pages in the same area may be placed in the area's InitializeContext method.
        /// </remarks>
        protected virtual void InitializeContext() { }

        /// <summary>
        /// Set up the security items for the page. 
        /// Called by LayoutViewModel.Init() method after InitializeContext().
        /// </summary>
        protected virtual void InitializePageSecurity() { }

        /// <summary>
        /// Set up the page elements.
        /// Called by LayoutViewModel.Load() method.
        /// </summary>
        /// <remarks>
        /// DevNote: Checking for Context.IsPostBack may be necessary. Most UI items only need to be set on initial load.
        /// </remarks>
        protected virtual void InitializeView() { }

        #endregion Virtual Methods

        #region Public Methods

        ///// <summary>
        ///// Returns the value of the <see cref="MessageBoxViewModel.ShowMessageBox"/>.
        ///// </summary>
        //public bool GetShowMessageBoxValue()
        //{
        //    return MessageBox != null && MessageBox.ShowMessageBox;
        //}

        /// <summary>
        /// Sets the title for the page on both the browser tab and in the TitleBar.
        /// </summary>
        /// <param name="title">The plain text string title for the page and TitleBar.</param>
        public void SetPageTitle(string title)
        {
            PageTitle = title;
            TitleBar.TitleText = title;
        }

        #endregion Public Methods

        #region Private Methods

        ///// <summary>
        ///// Display the MessageBox if there is a OneTimeMessage to show.
        ///// </summary>
        //private void ShowOneTimeMessageIfNeeded()
        //{
        //    if (string.IsNullOrEmpty(MessageKey))
        //        return;

        //    if (!string.IsNullOrEmpty(MessageKeyArgs))
        //    {
        //        MessageBox.ShowSuccessOneTime(MessageKey, MessageKeyArgs.Split(','));
        //    }
        //    else
        //    {
        //        MessageBox.ShowSuccessOneTime(MessageKey);
        //    }
        //}

        #endregion Private Methods
    }
}

