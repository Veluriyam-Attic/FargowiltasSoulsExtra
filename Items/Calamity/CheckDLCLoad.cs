//global using FargowiltasSoulsExtra.Items.Calamity;
using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Items.Calamity
{
    public class CheckDLCLoad : ModSystem
    {
        public static bool IsDLCLoad => ModLoader.HasMod("FargowiltasCrossmod") ? true : false;
    }
}
