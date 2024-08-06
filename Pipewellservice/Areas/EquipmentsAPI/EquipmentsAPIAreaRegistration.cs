using System.Web.Mvc;

namespace Pipewellservice.Areas.EquipmentsAPI
{
    public class EquipmentsAPIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EquipmentsAPI";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EquipmentsAPI_default",
                "EquipmentsAPI/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}