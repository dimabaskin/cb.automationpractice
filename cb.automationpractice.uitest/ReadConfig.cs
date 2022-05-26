using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace cb.automationpractice.uitest
{
    internal class ReadConfig
    {
        public static readonly IConfigurationRoot appConfig = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(path: "appconfig.json")
           .Build();

        public static readonly IConfigurationRoot testData = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(path: "TestData//testData.json")
           .Build();
    }
}
