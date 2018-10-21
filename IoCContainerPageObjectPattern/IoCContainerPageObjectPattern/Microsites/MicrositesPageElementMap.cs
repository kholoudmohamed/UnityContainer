using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCContainerPageObjectPattern.Base;

using OpenQA.Selenium;

namespace IoCContainerPageObjectPattern.Microsites
{
    public class MicrositesPageElementMap : BasePageElementMap
    {
        public IWebElement AllPortfoliosLink => browser.FindElement(By.LinkText("All Portfolios"));
        public IList<IWebElement> QuickLinks => browser.FindElements(By.CssSelector("div.content-wrapper>ul>li>span>a"));
        public IWebElement Header => browser.FindElement(By.CssSelector("div.mega-menu > div > div > div.container> div >div> div"));
        public IWebElement SubHeader => browser.FindElement(By.Id("AAMResponsiveMicrositeMenu_responsiveMicrositeHeaderDisclosureContentReader_uxContent"));
        public IWebElement MicrositeBody => browser.FindElement(By.CssSelector("div.detail-content>div.text-container"));
        public IWebElement MicrositeFooter => browser.FindElement(By.CssSelector("div.microsite-footer > div:nth-child(2) > div"));
        public IList<IWebElement> FirstTrustOfEarchUitGridSection => browser.FindElements(By.XPath(".//*[contains(@id,'ctl00_mainContentPlaceHolder_')][contains(@id,'nitInvestmentTrustsControl_')][contains(@id,'_ctl00_ctl04_lnkTrustName')] "));

        // Cohen & Steers Customized UIT portfolio Links
        public IWebElement CohenSteersClosedEndUitLink => browser.FindElement(By.LinkText("Closed-End Fund UITs"));
        public IWebElement CohenSteersPreferredUitLink => browser.FindElement(By.LinkText("Preferred UITs"));
        public IWebElement CohenSteersEquityUitLink => browser.FindElement(By.LinkText("Equity UITs"));
    }
}
