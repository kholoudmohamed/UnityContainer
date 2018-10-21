using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCContainerPageObjectPattern.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IoCContainerPageObjectPattern.Base
{
    public class BasePage<M>
        where M : BasePageElementMap, new()
    {
        protected readonly string Pageurl;
        protected M Map => new M();
        public BasePage(string url)
        {
            this.Pageurl = url;
        }

        public BasePage()
        {
            this.Pageurl = null;
        }

        public virtual void Navigate()
        {
            Driver.Browser.Navigate().GoToUrl(string.Concat(GetData.BaseAddress, this.Pageurl));
        }
    }
}
