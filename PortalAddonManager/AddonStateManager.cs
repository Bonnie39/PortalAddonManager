using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAddonManager
{
    internal class AddonStateManager
    {
        //take enabled addon name and append .inactive (declared by disabled name)
        public static void Disable(string enabledAddonName, string disabledAddonName)
        {
            File.Copy(enabledAddonName, disabledAddonName, true);
            File.Delete(enabledAddonName);

            if (!File.Exists(enabledAddonName))
            {
                Console.WriteLine("Rename Successful");
            }
        }

        //take disabled name and revert back to active (remove .inactive)
        public static void Enable(string disabledAddonName, string enabledAddonName)
        {
            if(File.Exists(disabledAddonName))
            {
                File.Copy(disabledAddonName, enabledAddonName, true);
                File.Delete(disabledAddonName);
            }

            if (!File.Exists(disabledAddonName))
            {
                Console.WriteLine("Rename Successful");
            }
        }
    }
}
