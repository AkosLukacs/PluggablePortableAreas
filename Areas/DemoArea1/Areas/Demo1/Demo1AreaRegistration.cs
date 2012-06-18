using System.Web.Mvc;
using MvcContrib.PortableAreas;
using PluggablePortableAreas.Common;
using System.Diagnostics;

namespace DemoArea1.Areas.Demo1
{
    public class Demo1AreaRegistration : PortableAreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Demo1";
            }
        }
        public string DefaultController { get { return "Demo"; } }
        public string DefaultAction { get { return "Index"; } }

        public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
        {
            bus.Send(new RegisterAreaMessage("Link to the Demo area", AreaName, DefaultController, DefaultAction));

            RegisterRoutes(context);

            RegisterAreaEmbeddedResources();
        }

        private void RegisterRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
              AreaName + "_Content",
              base.AreaRoutePrefix + "/Content/{resourceName}",
              new { controller = "EmbeddedResource", action = "Index", resourcePath = "Content" },
              new[] { "MvcContrib.PortableAreas" }
          );

            context.MapRoute(
                AreaName + "_default",
                AreaName + "/{controller}/{action}/{id}",
                new { action = DefaultAction, id = UrlParameter.Optional }
            );
        }
    }
}
