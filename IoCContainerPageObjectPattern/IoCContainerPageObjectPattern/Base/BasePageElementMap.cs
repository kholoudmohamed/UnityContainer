using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCContainerPageObjectPattern.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IoCContainerPageObjectPattern.Base
{
    public class BasePageElementMap
    {
        protected IWebDriver browser;
        protected WebDriverWait browserWait;

        public BasePageElementMap()
        {
            this.browser = Driver.Browser;
            this.browserWait = Driver.BrowserWait;
        }
        // Breadcrumbs elements
        public IList<IWebElement> BreadCrumbItems => Driver.Browser.FindElements(By.CssSelector("[id*= '_uxAAMWebBreadcrumbs_uxBreadcrumbSiteMap_uxBreadcrumb']"));
        public IList<IWebElement> BlogBreadCrumbItems => Driver.Browser.FindElements(By.CssSelector("[id*= '_uxAAMWebBlogBreadcrumbs_']"));
        public IList<IWebElement> MicrositesBreadCrumbItems => Driver.Browser.FindElements(By.CssSelector("[id*= '_uxBreadcrumbSiteMap_uxBreadcrumb']"));

        // Pages Title and text under it (subject) displayed on banner/slim banner
        public IWebElement PageTitleOnBanner => Driver.Browser.FindElement(By.CssSelector(".bannercontent.row>div.container>div>div>div>div>div.title"));
        public IWebElement PageSubjectOnBanner => Driver.Browser.FindElement(By.CssSelector(".bannercontent.row>div.container>div>div>div>div>div.subject"));

        public void SwitchToDefault()
        {
            this.browser.SwitchTo().DefaultContent();
        }
    }
}
