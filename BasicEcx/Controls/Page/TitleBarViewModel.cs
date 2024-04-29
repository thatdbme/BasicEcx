using BasicEcx.Common.Navigation;
using BasicEcx.Models;
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicEcx.Controls.Page
{
    public class TitleBarViewModel : DotvvmViewModelBase
    {
        
        #region Delegates and Events

        public delegate void TitleBarActionButtonEventHandler(TitleBarButton sender);

        public event TitleBarActionButtonEventHandler TabActionButtonClicked;
        public event TitleBarActionButtonEventHandler PageActionButtonClicked;
        public event TitleBarActionButtonEventHandler MoreActionsMenuItemClicked;

        #endregion Delegates and Events


        #region Public Properties

        /// <summary>
        /// Fake object to bypass validation.
        /// </summary>
        public object Decoy { get; set; } = new object();

        /// <summary>
        /// The list of More Actions.
        /// </summary>
        [Bind(Direction.ServerToClient)]
        public List<TitleBarButton> MoreActions { get; private set; }

        /// <summary>
        /// The resource key used to set the display text of the More Actions Menu.
        /// </summary>
        /// <remarks>
        /// Defaults to PageResourcing.MoreActions when no value is provided.
        /// </remarks>
        [Bind(Direction.None)]
        public string MoreActionsMenuResourceKey { get; set; }

        /// <summary>
        /// The text to display for the More Actions Menu.
        /// </summary>
        /// <remarks>
        /// The value is set using the MoreActionsMenuResourceKey property.
        /// </remarks>
        [Bind(Direction.None)]
        public string MoreActionsMenuText { get; private set; }

        /// <summary>
        /// The list of navigation links that appears in the title bar.
        /// </summary>
        [Bind(Direction.ServerToClientFirstRequest)]
        public List<TitleBarLink> NavLinks { get; private set; }

        /// <summary>
        /// The list of Page Actions.
        /// </summary>
        [Bind(Direction.ServerToClient)]
        public List<TitleBarButton> PageActions { get; private set; }

        /// <summary>
        /// The list of Tab Actions.
        /// </summary>
        [Bind(Direction.ServerToClient)]
        public List<TitleBarButton> TabActions { get; private set; }

        /// <summary>
        /// The text to display as the title of the page.
        /// </summary>
        [Bind(Direction.Both)]
        public string TitleText { get; set; }

        #endregion Public Properties

        #region Public Display Properties

        /// <summary>
        /// Gets a value that indicates if the TitleBarToggler control should be included in the page or not. Defaults to true.
        /// </summary>
        [Bind(Direction.None)]
        public bool DisplayTitleBarToggler { get; private set; } = true;

        [Bind(Direction.None)]
        public string TitleBarNavCssString { get; private set; } = CssClasses.TITLE_BAR_NAV_DEFAULT;

        [Bind(Direction.None)]
        public string TitleBarActionsCssString { get; private set; } = CssClasses.TITLE_BAR_ACTIONS_DEFAULT;

        /// <summary>
        /// The string value needed for the data-delay attribute on tooltip.
        /// </summary>
        [Bind(Direction.None)]
        public string TooltipDataDelayValue => "{\"show\": 500}";

        #endregion Public Display Properties

        #region Page Lifecycle Methods

        public TitleBarViewModel() {}

        public override Task PreRender()
        {
            UpdateTitleBarNavAttributes();

            MoreActionsMenuText = GetMoreActionsMenuText();

            return base.PreRender();
        }

        #endregion Page Lifecycle Methods

        #region Public NavLinks Methods

        /// <summary>
        /// Add a single value to the NavLinks collection.
        /// </summary>
        public void AddNavLink(NavPageViewModel page)
        {
            if (NavLinks == null)
                NavLinks = new List<TitleBarLink>();

            NavLinks.Add(new TitleBarLink
            {
                Text = page.ResourceKey,
                ResourceKey = page.ResourceKey,
                Url = page.Url,
                CssClass = page.ResourceKey
            });
        }

        /// <summary>
        /// Add multiple values to the NavLinks collection.
        /// </summary>
        public void AddNavLinks(IEnumerable<NavPageViewModel> pages)
        {
            if (NavLinks == null)
                NavLinks = new List<TitleBarLink>();

            NavLinks.AddRange(pages.Select(page => new TitleBarLink
            {
                Text = GetNavLinkText(page.ResourceKey, page.CustomName),
                ResourceKey = page.ResourceKey,
                Url = page.Url,
                CssClass = page.ResourceKey
            }));
        }

        #endregion Public NavLinks Methods

        #region Public TabActions Methods

        /// <summary>
        /// Add a new TabAction button to the page.
        /// </summary>
        /// <param name="resourceKey">The ResourceKey containing the text for the button.</param>
        /// <param name="eventCode">A unique int value used by the page to determine what action to associate with this button.</param>
        /// <param name="skipPageValidation">An optional bool value that determines if page validation should be skipped when this button is clicked. Default value is false.</param>
        public void AddTabActionButton(string resourceKey, int eventCode, bool skipPageValidation = false)
        {
            if (TabActions == null)
                TabActions = new List<TitleBarButton>();

            TabActions.Add(new TitleBarButton
            {
                Type = TitleBarButtonType.TabAction,
                Text = resourceKey,
                EventCode = eventCode,
                CssClass = "btn btn-outline-primary btn-sm ml-1 ",
                SkipPageValidation = skipPageValidation
            });
        }
        
        /// <summary>
        /// Occurs when a TitleBar ActionButton of type TabAction is clicked.
        /// </summary>
        /// <remarks>
        /// The event is raised to be handled by the containing page.
        /// </remarks>
        /// <param name="button">The ActionButton that was clicked.</param>
        public void PageTabActionButtonClick(TitleBarButton button)
        {
            TabActionButtonClicked?.Invoke(button);
        }
        
        #endregion Public TabActions Methods

        #region Public PageActions Methods

        /// <summary>
        /// Add a new PageAction button to the page.
        /// </summary>
        /// <param name="resourceKey">The ResourceKey containing the text for the button.</param>
        /// <param name="eventCode">A unique int value used by the page to determine what action to associate with this button.</param>
        /// <param name="skipPageValidation">An optional bool value that determines if page validation should be skipped when this button is clicked. Default value is false.</param>
        public void AddPageActionButton(string resourceKey, int eventCode, bool skipPageValidation = false)
        {
            if (PageActions == null)
                PageActions = new List<TitleBarButton>();

            PageActions.Add(new TitleBarButton
            {
                Type = TitleBarButtonType.PageAction,
                Text = resourceKey,
                EventCode = eventCode,
                CssClass = "btn btn-outline-primary btn-sm ml-1 ",
                SkipPageValidation = skipPageValidation
            });
        }

        /// <summary>
        /// Occurs when a TitleBar ActionButton of type PageAction is clicked.
        /// </summary>
        /// <remarks>
        /// The event is raised to be handled by the containing page.
        /// </remarks>
        /// <param name="button">The ActionButton that was clicked.</param>
        public void PageActionButtonClick(TitleBarButton button)
        {
            PageActionButtonClicked?.Invoke(button);
        }

        #endregion Public PageActions Methods

        #region Public MoreActions Methods

        /// <summary>
        /// Add a new item to the MoreActionsMenu.
        /// </summary>
        /// <param name="resourceKey">The ResourceKey containing the text for the button.</param>
        /// <param name="eventCode">A unique int value used by the page to determine what action to associate with this button.</param>
        /// <param name="skipPageValidation">An optional bool value that determines if page validation should be skipped when this button is clicked. Default value is false.</param>
        public void AddMoreActionsMenuButton(string resourceKey, int eventCode, bool skipPageValidation = false)
        {
            if (MoreActions == null)
                MoreActions = new List<TitleBarButton>();

            MoreActions.Add(new TitleBarButton
            {
                Type = TitleBarButtonType.MoreActionsMenu,
                Text = resourceKey,
                EventCode = eventCode,
                SkipPageValidation = skipPageValidation
            });
        }

        /// <summary>
        /// Occurs when a TitleBar ActionButton in the MoreActions menu is clicked.
        /// </summary>
        /// <remarks>
        /// The event is raised to be handled by the containing page.
        /// </remarks>
        /// <param name="button">The ActionButton that was clicked.</param>
        public void MoreActionsMenuItemClick(TitleBarButton button)
        {
            MoreActionsMenuItemClicked?.Invoke(button);
        }
        
        #endregion Public MoreActions Methods

        #region Private Methods

        /// <summary>
        /// Returns the text to display for the More Actions Menu.
        /// </summary>
        private string GetMoreActionsMenuText()
        {
            if (string.IsNullOrEmpty(MoreActionsMenuResourceKey))
            {
                MoreActionsMenuResourceKey = "More Actions";
            }

            return MoreActionsMenuResourceKey;
        }

        /// <summary>
        /// Returns the text to be used for a NavLink.
        /// </summary>
        private static string GetNavLinkText(string resourceKey, string customName)
        {
            var text = resourceKey;
            if (!string.IsNullOrEmpty(customName))
            {
                text = string.Format(text, customName);
            }

            return text;
        }

        /// <summary>
        /// Updates attributes for various UI elements to display as needed.
        /// </summary>
        private void UpdateTitleBarNavAttributes()
        {
            var navLinkItemCount = NavLinks?.Count ?? 0;
            var tabActionItemCount = TabActions?.Count ?? 0;
            var pageActionItemCount = PageActions?.Count ?? 0;


            var itemCount = navLinkItemCount + tabActionItemCount + pageActionItemCount;

            // If there are 1 or 0 total NavLink, TabAction, or PageAction items then update the CSS
            // of the TitleBarNav and TitleBarActions elements to avoid collapsing to a menu on skinny screens.
            if (itemCount <= 1)
            {
                DisplayTitleBarToggler = false;
                TitleBarNavCssString = CssClasses.TITLE_BAR_NAV_DO_NOT_COLLAPSE;
                TitleBarActionsCssString = CssClasses.TITLE_BAR_ACTIONS_DO_NOT_COLLAPSE;
            }
        }

        #endregion Private Methods

        #region Helper Classes

        /// <summary>
        /// CSS Class strings to use for various TitleBar elements.
        /// </summary>
        public class CssClasses
        {
            /// <summary>
            /// The default CSS string for the TitleBarNav element. Allows collapsing.
            /// </summary>
            /// <remarks>
            /// Use when there are 2 or more total TitleBarNav plus TitleBarActions items.
            /// </remarks>
            public const string TITLE_BAR_NAV_DEFAULT = "navbar navbar-expand-md navbar-light bg-light";
            /// <summary>
            /// The CSS string for the TitleBarNav element when collapsing is not allowed.
            /// </summary>
            /// <remarks>
            /// Use when there are 0 or 1 total TitleBarNav plus TitleBarActions items.
            /// </remarks>
            public const string TITLE_BAR_NAV_DO_NOT_COLLAPSE = "navbar xx1 navbar-light bg-light";

            /// <summary>
            /// The default CSS string for the TitleBarActions element. Allows collapsing.
            /// </summary>
            /// <remarks>
            /// Use when there are 2 or more total TitleBarNav plus TitleBarActions items.
            /// </remarks>
            public const string TITLE_BAR_ACTIONS_DEFAULT = "collapse navbar-collapse titleBarActions";
            /// <summary>
            /// The CSS string for the TitleBarActions element when collapsing is not allowed.
            /// </summary>
            /// <remarks>
            /// Use when there are 0 or 1 total TitleBarNav plus TitleBarActions items.
            /// </remarks>
            public const string TITLE_BAR_ACTIONS_DO_NOT_COLLAPSE = "xx3 xx2 titleBarActions";
        }

        #endregion Helper Classes
    }
}