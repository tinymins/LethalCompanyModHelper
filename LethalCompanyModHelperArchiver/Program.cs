using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace LethalCompanyModHelperArchiver
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.UserSettingsUpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UserSettingsUpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        internal static string GetI18nString(string originalString, string cultureName = null)
        {
            if (string.IsNullOrEmpty(cultureName))
            {
                cultureName = CultureInfo.CurrentCulture.Name;
            }

            // culture-specific file, i.e. "zh-CN"
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"LethalCompanyModHelperArchiver.I18n.{cultureName}.resources");

            // resource not found, revert to default resource
            if (null == stream)
            {
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LethalCompanyModHelperArchiver.I18n.default.resources");
            }

            ResourceReader reader = new ResourceReader(stream);
            IDictionaryEnumerator en = reader.GetEnumerator();
            while (en.MoveNext())
            {
                if (en.Key.Equals(originalString))
                {
                    return en.Value.ToString();
                }
            }

            // string not translated, revert to original string
            return originalString;
        }
    }
}
