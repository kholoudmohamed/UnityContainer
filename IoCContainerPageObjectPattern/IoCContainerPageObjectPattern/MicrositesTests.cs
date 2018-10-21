using System;
using IoCContainerPageObjectPattern.Base;
using IoCContainerPageObjectPattern.Core;
using IoCContainerPageObjectPattern.Microsites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Unity;
using Unity.Lifetime;
using TestContext = NUnit.Framework.TestContext;

namespace IoCContainerPageObjectPattern
{
    [TestFixture]
    public class MicrositesTests:BaseTest
    {
        [Test, Theory]
        public void CohenSteersTest(Enum.Microsites site)
        {
            var micrositePage = Helpers.RegisterRelevantMicrositePage(site);
            micrositePage.Navigate();

            micrositePage.Validate_IsHeaderTextDisplayedCorrectly();
            micrositePage.Validate_IsSubHeaderTextDisplayedCorrectly();
            micrositePage.Validate_IsMicrositeBodyTextCorrect();
            micrositePage.Validate_IsMicrositeDisclaimerTextCorrect();
        }
    }
}
