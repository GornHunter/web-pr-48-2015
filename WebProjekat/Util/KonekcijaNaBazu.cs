using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Util
{
    public class KonekcijaNaBazu
    {
        public static string Konekcija
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString;
            }
        }

    }
}