﻿using System.Web;
using System.Web.Mvc;

namespace doan_qlDuan_CNTT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
