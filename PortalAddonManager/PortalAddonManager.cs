using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace PortalAddonManager
{
    public partial class PortalAddonManager : Form
    {
        private string? localSteamPath = GameDataPaths.steamPath;
        private string? localPortalAddonPath = GameDataPaths.portalAddonPath;
        public PortalAddonManager()
        {
            InitializeComponent();
            CheckSerializedPath();
            GetPortalAddonPath();
        }

        #region MY_FUNCTIONS
        private void GetPortalAddonPath()
        {
            if(localSteamPath == null)
            {
                Process[] steam = Process.GetProcessesByName("steam");
                if (steam.Length > 0)
                {
                    localSteamPath = steam[0].MainModule.FileName;

                    if(localSteamPath != null)
                    {
                        localSteamPath = localSteamPath.Remove(29, 9);
                    }

                    if(localPortalAddonPath == null)
                    {
                        localPortalAddonPath = localSteamPath + "steamapps\\common\\Portal\\portal\\custom";
                    }

                    Debug.WriteLine(localPortalAddonPath);
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

        private void CheckSerializedPath()
        {
            Debug.WriteLine("Serialization not implemented yet :(");
        }
        #endregion
    }
}