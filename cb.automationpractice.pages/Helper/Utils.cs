using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cb.automationpractice.pages.Helper
{
    public class Utils
    {
        public static readonly IConfigurationRoot pageElements = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(path: "PageElements\\PageElements.json")
           .Build();

        
    }
}
