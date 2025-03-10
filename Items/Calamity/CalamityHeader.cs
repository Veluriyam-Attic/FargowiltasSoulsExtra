using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSoulsExtra.Items.Calamity.Enchantments.BHardmode;
using Terraria.ModLoader;
namespace FargowiltasSoulsExtra.Items.Calamity;

    public class EarthHeader : EnchantHeader
    {
        public override int Item => ModContent.ItemType<EarthForce>();
        public override float Priority => 10f;
    }