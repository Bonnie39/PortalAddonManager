using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace PortalAddonManager
{
    public partial class PortalAddonManager : Form
    {
        private string? steamPath;
        private string? portalAddonPath;

        private static string? testAddon;
        private static string? addonDestination;
        public PortalAddonManager()
        {
            InitializeComponent();
            //CheckSerializedPath();
            GetPortalAddonPath();

            checkedListBox1.SetItemChecked(0, true);
        }

        #region MY_FUNCTIONS
        private void GetPortalAddonPath()
        {
            if(steamPath == null)
            {
                Process[] steam = Process.GetProcessesByName("steam");
                if (steam.Length > 0)
                {
                    steamPath = steam[0].MainModule.FileName;

                    if(steamPath != null)
                    {
                        steamPath = steamPath.Remove(29, 9);
                    }

                    if(portalAddonPath == null)
                    {
                        portalAddonPath = steamPath + "steamapps\\common\\Portal\\portal\\custom";
                    }

                    Debug.WriteLine(portalAddonPath);
                    LookForAddons(portalAddonPath);
                }
                else
                {
                    Debug.WriteLine("Unable to find Steam. Make sure it is open.");
                }
            }
            else
            {
                return;
            }
        }

        private static void LookForAddons(string addonLocation)
        {
            string[] addons = Directory.GetFiles(addonLocation, "*.vpk");

            if(addons.Length > 0)
            {
                testAddon = addons[0];
                addonDestination = testAddon + ".inactive";

                Debug.WriteLine(testAddon);

            } else
            {
                Console.WriteLine("No addons found");
            }
            
        }

        private static void CheckSerializedPath()
        {
            Debug.WriteLine("Serialization not implemented yet :(");
        }
        #endregion

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if we uncheck, disable the addon
            if(checkedListBox1.GetItemChecked(0) != false)
            {
                if(testAddon != null && addonDestination != null)
                {
                    AddonStateManager.Disable(testAddon, addonDestination);
                }
                else
                {
                    Console.WriteLine("How the fuck?");
                }
            }

            //if we check, enable the addon
            if(checkedListBox1.GetItemChecked(0) == false)
            {
                if (testAddon != null && addonDestination != null)
                {
                    AddonStateManager.Enable(addonDestination, testAddon);
                }
                else
                {
                    Console.WriteLine("How the fuck?");
                }
            }
        }
    }
}