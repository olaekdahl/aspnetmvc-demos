using Socrates.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace Socrates.Controllers
{
    public class BaseController : Controller
    {
        public ISocratesContext ctx;

        public BaseController()
        {
            string conn = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            ctx = SocratesContextFactory.GetContext(conn);
        }

        //protected override void Initialize(RequestContext requestContext)
        //{

        //    string conn = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    ctx = SocratesContextFactory.GetContext(conn);
        //}
    }
}