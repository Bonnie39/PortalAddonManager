using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace PortalAddonManager
{
    internal class FileDownloader
    {
        public static void DownloadSelectedAddon(string addonPath, string downloadedFileName, string addonFileUrl)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += ProgressUpdate;
                wc.DownloadFileAsync(
                    // Link to file
                    new System.Uri(addonFileUrl),
                    // Path to save downloaded file to
                    addonPath + downloadedFileName
                );
            }
        }

        public static void ProgressUpdate(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar.Value = e.ProgressPercentage;
        }
    }
}
