using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IoCContainerPageObjectPattern.Microsites;
using Unity;
using Unity.Lifetime;

namespace IoCContainerPageObjectPattern.Core
{
    public class Helpers
    {
        public static string GetPlainTextFromHtml(string htmlCode)
        {
            // Remove new lines since they are not visible in HTML
            htmlCode = htmlCode.Replace("\n", " ");

            // Remove tab spaces
            htmlCode = htmlCode.Replace("\t", " ");

            // Remove multiple white spaces from HTML
            htmlCode = Regex.Replace(htmlCode, "\\s+", " ");

            // Remove HEAD tag
            htmlCode = Regex.Replace(htmlCode, "<head.*?</head>", ""
                                , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Remove any JavaScript
            htmlCode = Regex.Replace(htmlCode, "<script.*?</script>", ""
              , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Replace special characters like &, <, >, " etc.
            var sbHtml = new StringBuilder(htmlCode);
            // Note: There are many more special characters, these are just
            // most common. You can add new characters in this arrays if needed
            string[] oldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;",
   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
            string[] newWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢" };
            for (var i = 0; i < oldWords.Length; i++)
            {
                sbHtml.Replace(oldWords[i], newWords[i]);
            }

            // Check if there are line breaks (<br>) or paragraph (<p>)
            sbHtml.Replace("<br>", "\n<br>");
            sbHtml.Replace("<br ", "\n<br ");
            sbHtml.Replace("<p ", "\n<p ");

            // Finally, remove all HTML tags and return plain text
            return System.Text.RegularExpressions.Regex.Replace(
              sbHtml.ToString(), "<[^>]*>", "");
        }

        public static string ConvertListOfStringsToSingleStringArrowSeparated(List<string> list)
        {
            var builder = new StringBuilder();
            foreach (var item in list)
            {
                builder.Append(item).Append(">");
            }
            return builder.ToString();
        }

        private static readonly IUnityContainer PageFactory = new UnityContainer();

        #region
        public static IMicrositesPage RegisterRelevantMicrositePage(Enum.Microsites site)
        {
            IMicrositesPage micrositePage;
            switch (site)
            {
                case Enum.Microsites.CohenAndSteers:
                    PageFactory.RegisterType<IMicrositesPage, CohenSteersPage>(new ContainerControlledLifetimeManager());
                    micrositePage = PageFactory.Resolve<IMicrositesPage>();
                    break;
                case Enum.Microsites.MerrillLynch:
                    PageFactory.RegisterType<IMicrositesPage, CohenSteersPage>(new ContainerControlledLifetimeManager());
                    micrositePage = PageFactory.Resolve<IMicrositesPage>();
                    break;
                case Enum.Microsites.MorganStanley:
                    PageFactory.RegisterType<IMicrositesPage, MorganStanleyPage>(new ContainerControlledLifetimeManager());
                    micrositePage = PageFactory.Resolve<IMicrositesPage>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(site), site, null);

            }
            return micrositePage;
        }
        #endregion

    }
}
