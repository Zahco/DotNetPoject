using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Helpers
{
    public static class HtmlExtensions
    {
        public static string RandomID(this HtmlHelper htmlHelper)
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}