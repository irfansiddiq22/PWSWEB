using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Helper
{
    public class BaseController : Controller
    {
        // GET: Base
     /*   protected override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var cultureInfo = CultureInfo.GetCultureInfo("ar-SA");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.CurrentCulture = cultureInfo;

        }*/

    }
    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            try
            {
                DateTime date = DateTime.ParseExact(value.AttemptedValue.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return date;
            }catch(Exception e)
            {
                return null;
            }
            

            
            
        }
    }

}