using BasicEcx.Controls.Page;
using DotVVM.Framework.ViewModel;
using System.Threading.Tasks;

namespace BasicEcx.MasterPages
{
    public class LayoutViewModel : DotvvmViewModelBase
    {
        #region Public Properties Not Part of the Viewmodel

        /// <summary>
        /// The UserId of the logged-in user.
        /// </summary>
        [Bind(Direction.None)]
        public int UserId => 123456;

        #endregion Public Properties Not Part of the Viewmodel

        #region ViewModel Properties

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
        /// <remarks>
        /// DevNote: The PageParameter variables are set and can be used now.
        /// </remarks>
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

        #region Public Virtual Methods

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

        #endregion Public Virtual Methods

        #region Public Methods

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
    }
}

