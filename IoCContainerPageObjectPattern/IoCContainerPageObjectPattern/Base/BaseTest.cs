using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCContainerPageObjectPattern.Core;
using NUnit.Framework;

namespace IoCContainerPageObjectPattern.Base
{
    public class BaseTest:Driver
    {
        [SetUp]
        public void SetupTest()
        {
            StartBrowser();
        }

        [TearDown]
        public void TeardownTest()
        {
            StopBrowser();
        }
    }
}
