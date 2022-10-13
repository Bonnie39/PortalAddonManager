using System;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using Newtonsoft.Json;

namespace PortalAddonManager
{
    public partial class PortalAddonManager : Form
    {
        private string? steamPath;
        private string? portalAddonPath;

        private static string? addonOrigin;
        private static string? addonDestination;

        private readonly string[] addons = Array.Empty<string>();
        private readonly string[] disabledAddons = Array.Empty<string>();
        private string[] fullAddonList = Array.Empty<string>();

        public PortalAddonManager()
        {
            InitializeComponent();
            GetPortalAddonPath();


            if (portalAddonPath != null)
            {
                addons = Directory.GetFiles(portalAddonPath, "*.vpk");
                disabledAddons = Directory.GetFiles(portalAddonPath, "*.inactive");
                LookForAddons();
            }

        }

        #region MY_FUNCTIONS
        private void GetPortalAddonPath()
        {
            if (steamPath == null)
            {
                Process[] steam = Process.GetProcessesByName("steam");
                if (steam.Length > 0)
                {
                    steamPath = steam[0].MainModule.FileName;

                    if (steamPath != null)
                    {
                        steamPath = steamPath.Remove(29, 9);
                    }

                    if (portalAddonPath == null)
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


            // Add each .vpk addon file to the checkedboxlist and set it to active by default if enabled and inactive by default if disabled
            if (addons != null | disabledAddons != null)
            {

                fullAddonList = addons.Concatenate(disabledAddons);

                string? temp2;
                string? temp3;
                string? jsonFile;

                for (int i = 0; i < fullAddonList.Length; i++)
                {
                    string? temp = Path.GetFileName(fullAddonList[i]);

                    if (temp.EndsWith(".inactive"))
                    {
                        temp2 = temp.Remove(temp.Length - 9, 9);
                        temp3 = temp.Remove(temp.Length - 13, 13);

                        jsonFile = portalAddonPath + "\\" + temp3 + ".json";
                        if (File.Exists(jsonFile))
                        {

                            Debug.WriteLine(jsonFile);

                            using StreamReader file = File.OpenText(jsonFile);

                            JsonSerializer serializer = new JsonSerializer();
                            Addon addon = (Addon)serializer.Deserialize(file, typeof(Addon));

                            if (addon != null)
                            {
                                checkedListBox1.Items.Insert(i, new Addon { Name = addon.Name, Description = "test" });
                                checkedListBox1.SetItemChecked(i, false);
                            }

                        }
                        else
                        {
                            checkedListBox1.Items.Insert(i, new Addon { Name = temp2, Description = "test" });
                            checkedListBox1.SetItemChecked(i, false);
                        }
                    }
                    else
                    {
                        temp2 = temp;
                        temp3 = temp.Remove(temp.Length - 4, 4);
                        jsonFile = portalAddonPath + "\\" + temp3 + ".json";
                        if (File.Exists(jsonFile))
                        {
                            Debug.WriteLine(jsonFile);
                            using StreamReader file = File.OpenText(jsonFile);

                            JsonSerializer serializer = new JsonSerializer();
                            Addon addon = (Addon)serializer.Deserialize(file, typeof(Addon));

                            if (addon != null)
                            {
                                checkedListBox1.Items.Insert(i, new Addon { Name = addon.Name, Description = "test" });
                                checkedListBox1.SetItemChecked(i, true);
                            }
                        }
                        else
                        {
                            checkedListBox1.Items.Insert(i, new Addon { Name = temp2, Description = "test" });
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }
#endregion

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If we uncheck, disable the addon
            if (checkedListBox1.GetItemChecked(e.Index) != false)
            {
                if (fullAddonList != null)
                {
                    if (fullAddonList[e.Index].EndsWith(".inactive"))
                    {
                        addonOrigin = fullAddonList[e.Index].ToString().Remove(fullAddonList[e.Index].Length - 9, 9);
                    }
                    else
                    {
                        addonOrigin = fullAddonList[e.Index].ToString();
                    }
                }

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
            if (checkedListBox1.GetItemChecked(e.Index) == false)
            {
                if (fullAddonList != null)
                {
                    if (fullAddonList[e.Index].EndsWith(".inactive"))
                    {
                        addonOrigin = fullAddonList[e.Index].ToString().Remove(fullAddonList[e.Index].Length - 9, 9);
                    }
                    else
                    {
                        addonOrigin = fullAddonList[e.Index].ToString();
                    }
                }

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


    public static class ConcatFunction
    {
        public static T[] Concatenate<T>(this T[] first, T[] second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            return first.Concat(second).ToArray();
        }
    }
}