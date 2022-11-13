using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace UserManagement_Project.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
     
            public ActionResult SetLanguage(int id)
            {
                Helper.Language.CurrentCulture = id;
                if (Request.UrlReferrer is null)
                {
                    return RedirectToAction("/");
                }
            return Redirect(Request.UrlReferrer.ToString());
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture =
                Helper.Language.Culture ?? Helper.Language.LangCultureInfo;
        }
    }
}
