using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace Testing
{

    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        ClassName,
        CssName
    }

    class PropertiesCollection
    {

        public static IWebDriver driver { get; set; }

    }
}
