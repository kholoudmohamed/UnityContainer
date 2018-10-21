using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCContainerPageObjectPattern.Base;
using IoCContainerPageObjectPattern.Core;
using NUnit.Framework;

namespace IoCContainerPageObjectPattern.Microsites
{
    public class MerrilLynchPage : BasePage<MicrositesPageElementMap>, IMicrositesPage
    {
        public MerrilLynchPage() : base(@"/MerrillLynch/mllanding")
        { }
        // Actions
        #region
        public void ClickOnAllPortfoliosLink()
        {
            try
            {
                Map.AllPortfoliosLink.Click();
            }
            catch (Exception)
            {
                Map.QuickLinks.Last().Click();
            }
        }
        public void ClickOnFirstTrust()
        {
            Map.FirstTrustOfEarchUitGridSection[0].Click();
        }
        #endregion

        //Validators
        #region
        public void Validate_IsHeaderTextDisplayedCorrectly()
        {
            Assert.AreEqual(MicrositesTestData.LandingHeaderText, Helpers.GetPlainTextFromHtml(Map.Header.Text), "Microsite Header text is not displayed correctly.");
        }
        public void Validate_IsSubHeaderTextDisplayedCorrectly()
        {
            Assert.AreEqual(MicrositesTestData.MerrillLynchLandingSubHeaderText, Helpers.GetPlainTextFromHtml(Map.SubHeader.Text), "Microsite Sub Header text is not displayed correctly.");
        }
        public void Validate_IsMicrositeBodyTextCorrect()
        {
            Assert.AreEqual(Helpers.GetPlainTextFromHtml(MicrositesTestData.MerrillLynchBodyText), Helpers.GetPlainTextFromHtml(Map.MicrositeBody.Text), "Microsite Body Text is not displayed correctly.");
        }
        public void Validate_IsMicrositeDisclaimerTextCorrect()
        {
            Assert.IsTrue(Helpers.GetPlainTextFromHtml(Map.MicrositeFooter.Text).Contains(Helpers.GetPlainTextFromHtml(MicrositesTestData.Disclaimer)), "Microsite disclaimer text is not displayed correctly.");
            Assert.IsTrue(Map.MicrositeFooter.Text.Contains("Copyright © " + DateTime.Today.Year), "Microsite disclaimer copyrights have a wrong year.");
        }
        #endregion
    }
}
