using System;
using System.Linq;
using IoCContainerPageObjectPattern.Base;
using IoCContainerPageObjectPattern.Core;
using NUnit.Framework;

namespace IoCContainerPageObjectPattern.Microsites
{
    public class CohenSteersPage:BasePage<MicrositesPageElementMap>,IMicrositesPage
    {
        public CohenSteersPage():base(@"/CohenSteers/cslanding")
        { }
        // Actions
        #region
        public void ClickOn_CohenAndSteers_ClosedEndUits()
        {
            Map.CohenSteersClosedEndUitLink.Click();
        }
        public void ClickOn_CohenAndSteers_PreferredUits()
        {
            Map.CohenSteersPreferredUitLink.Click();
        }
        public void ClickOn_CohenAndSteers_EquityUits()
        {
            Map.CohenSteersEquityUitLink.Click();
        }
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
            Assert.AreEqual(MicrositesTestData.CohenAndSteersLandingSubHeaderText, Helpers.GetPlainTextFromHtml(Map.SubHeader.Text), "Microsite Sub Header text is not displayed correctly.");
        }
        public void Validate_IsMicrositeBodyTextCorrect()
        {
            Assert.AreEqual(Helpers.GetPlainTextFromHtml(MicrositesTestData.CohenAndSteersBodyText), Helpers.GetPlainTextFromHtml(Map.MicrositeBody.Text), "Microsite Body Text is not displayed correctly.");
        }
        public void Validate_IsMicrositeDisclaimerTextCorrect()
        {
            Assert.IsTrue(Helpers.GetPlainTextFromHtml(Map.MicrositeFooter.Text).Contains(Helpers.GetPlainTextFromHtml(MicrositesTestData.Disclaimer)), "Microsite disclaimer text is not displayed correctly.");
            Assert.IsTrue(Map.MicrositeFooter.Text.Contains("Copyright © " + DateTime.Today.Year), "Microsite disclaimer copyrights have a wrong year.");
        }
        #endregion

    }
}
