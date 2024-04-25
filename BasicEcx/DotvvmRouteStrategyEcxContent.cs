using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicEcx
{
    /// <summary>
    /// Custom routing for the ECX Web application
    /// See: https://www.dotvvm.com/docs/tutorials/advanced-route-autodiscovery/2.0
    /// </summary>
    public class DotvvmRouteStrategyEcxContent : DefaultRouteStrategy
    {
        /// <summary>
        /// Prepares routes for the ECX application in the DotvvmContent folder
        /// All .dothtml files in DotvvmContent and its subfolders will be added to the RouteTable.
        /// </summary>
        public DotvvmRouteStrategyEcxContent(DotvvmConfiguration configuration, string viewsFolder = "Content", string pattern = "*.dothtml")
            : base(configuration, viewsFolder, pattern)
        {
            // Set the viewsFolder value to the root where you want dothtml files to be found
        }

        protected override string GetRouteName(RouteStrategyMarkupFileInfo file)
        {
            var name = base.GetRouteName(file);
            // Add custom logic here
            return name;
        }

        protected override string GetRouteUrl(RouteStrategyMarkupFileInfo file)
        {
            var url = base.GetRouteUrl(file);
            // Add custom logic here
            return url;
        }

        protected override object GetRouteDefaultParameters(RouteStrategyMarkupFileInfo file)
        {
            var parameters = base.GetRouteDefaultParameters(file);
            // Add custom logic here
            return parameters;
        }

    }
}