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

        private static string? addonOrigin;
        private static string? addonDestination;

        string[] addons;

        public PortalAddonManager()
        {
            InitializeComponent();
            GetPortalAddonPath();


            if (portalAddonPath != null)
            {
                addons = Directory.GetFiles(portalAddonPath, "*.vpk");
                LookForAddons();
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

        private void LookForAddons()
        {
            checkedListBox1.DisplayMember = "name";
            checkedListBox1.ValueMember = "description";

            // Add each .vpk addon file to the checkedboxlist and set it to active by default
            for (int i = 0; i < addons.Length; i++)
            {
                checkedListBox1.Items.Insert(i, new Addon { Name = Path.GetFileName(addons[i]), Description = "test" });
                checkedListBox1.SetItemChecked(i, true);
            }

        }

        #endregion

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If we uncheck, disable the addon
            if(checkedListBox1.GetItemChecked(e.Index) != false)
            {
                addonOrigin = addons[e.Index].ToString();
                addonDestination = addonOrigin + ".inactive";

                if (addonOrigin != null && addonDestination != null)
                {
                    AddonStateManager.Disable(addonOrigin, addonDestination);
                }
                else
                {
                    Console.WriteLine("How the fuck?");
                }
            }

            // If we check, enable the addon
            if(checkedListBox1.GetItemChecked(e.Index) == false)
            {
                addonOrigin = addons[e.Index].ToString();
                addonDestination = addonOrigin + ".inactive";

                if (addonOrigin != null && addonDestination != null)
                {
                    AddonStateManager.Enable(addonDestination, addonOrigin);
                }
                else
                {
                    Console.WriteLine("How the fuck?");
                }
            }
        }
    }
}