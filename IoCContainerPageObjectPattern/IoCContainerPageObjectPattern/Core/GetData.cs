using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace IoCContainerPageObjectPattern.Core
{
    public class GetData
    {
        // App.Config file data
        public static string BaseAddress => ConfigurationManager.AppSettings["BaseURL"];
    }
}
