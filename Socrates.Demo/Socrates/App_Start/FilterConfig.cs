﻿using Socrates.Filters;
using System.Web;
using System.Web.Mvc;

namespace Socrates
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuditFilter());
        }
    }
}
