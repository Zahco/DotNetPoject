using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Academy.Models
{
    public class GlobalVariables
    {
        public static HttpSessionState Session => HttpContext.Current.Session;
        public const string USER_ID_KEY = "UserId";
        public static bool IsAuthenticated => Session[USER_ID_KEY] != null;

        public static Guid UserId
        {
            get
            {
                if (IsAuthenticated)
                {
                    return Guid.Parse((string)Session[USER_ID_KEY]);
                }
                throw new Exception("User is not authenticate");
            }
            set
            {
                Session.Add(USER_ID_KEY, value.ToString());
            }
        }
    }
}