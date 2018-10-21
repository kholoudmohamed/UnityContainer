using System;

namespace IoCContainerPageObjectPattern.Microsites
{
    public interface IMicrositesPage
    {
        void Navigate();
        void ClickOnAllPortfoliosLink();
        void ClickOnFirstTrust();
        void Validate_IsHeaderTextDisplayedCorrectly();
        void Validate_IsSubHeaderTextDisplayedCorrectly();
        void Validate_IsMicrositeBodyTextCorrect();
        void Validate_IsMicrositeDisclaimerTextCorrect();
    }
}
