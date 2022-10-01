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
            GetPortalAddonPath();

            if(portalAddonPath != null)
            {
                LookForAddons(portalAddonPath);
            }

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

        private void LookForAddons(string addonLocation)
        {
            string[] addons = Directory.GetFiles(addonLocation, "*.vpk");

            checkedListBox1.DisplayMember = "name";
            checkedListBox1.ValueMember = "description";

            // Add each .vpk addon file to the checkedboxlist and set it to active by default
            for (int i = 0; i < addons.Length; i++)
            {
                checkedListBox1.Items.Insert(i, new Addon { Name = addons[i], Description = "test" });
                checkedListBox1.SetItemChecked(i, true);
            }


            if (addons.Length > 0)
            {
                testAddon = addons[0];
                addonDestination = testAddon + ".inactive";

                Debug.WriteLine(testAddon);

            } else
            {
                Console.WriteLine("No addons found");
            }
            
        }

        #endregion

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If we uncheck, disable the addon
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

            // If we check, enable the addon
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