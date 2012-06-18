using System.Web.Mvc;
using MvcContrib.PortableAreas;
using PluggablePortableAreas.Common;


namespace OtherExampleArea.Areas.Other
{
    public class OtherAreaRegistration : PortableAreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Other";
            }
        }
        public string DefaultController { get { return "Something"; } }
        public string DefaultAction { get { return "Index"; } }

        public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
        {
            bus.Send(new RegisterAreaMessage("Link to another area", AreaName, DefaultController, DefaultAction));

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
