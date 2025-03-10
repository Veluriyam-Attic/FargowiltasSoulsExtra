using System.Security.Cryptography.X509Certificates;
using CalamityMod.Items.Armor.Mollusk;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Enchantments;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Items.Calamity.Enchantments.BHardmode
{
    // 软壳魔石
	public class MolluskEnchant : BaseEnchant
	{
		public override Color nameColor => new Color(248, 146, 248);

        // public override bool IsLoadingEnabled(Mod mod)
        // {
		// 	return CheckDLCLoad.IsDLCLoad;
        // }

        public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.accessory = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = 150000;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<MolluskEnchantEffect>(Item);

            
        }
        // public override void AddRecipes()
        // {
        // 	Recipe recipe = CreateRecipe(1);
        // 	recipe.AddIngredient<MolluskShellmet>(1);
        // 	recipe.AddIngredient<MolluskShellplate>(1);
        // 	recipe.AddIngredient<MolluskShelleggings>(1);
        // 	recipe.AddIngredient<VictideEnchant>(1);
        // 	// recipe.AddIngredient(ModContent.<GiantPearl>(1));
        // 	// recipe.AddIngredient(ModContent.<AquaticEmblem>(1));
        // 	// recipe.AddIngredient(ModContent.<AmidiasPendant>(1));
        // 	recipe.AddTile(TileID.MythrilAnvil);
        // 	recipe.Register();
        // }
    }

    public class MolluskEnchantEffect : AccessoryEffect
    {
        
        public static int HitTime = 0;
        public override Header ToggleHeader => Header.GetHeader<EarthHeader>();
        public override void PostUpdateEquips(Player player)
        {
            // 忽略水
            player.ignoreWater = true;
			// 减20%速度，巫师魔石减10%
            player.moveSpeed -= player.ForceEffect<MolluskEnchantEffect>()? 0.1f:0.2f;
            HitTime++;
        }
    }

    public class MolluskPlayer: ModPlayer
    {
        public static bool CanAddDamage;
        public static float AddDamage = 1;
        public override void ResetEffects()
        {
            Player.GetDamage(DamageClass.Generic) += AddDamage;
            Player.moveSpeed -= Player.ForceEffect<MolluskEnchantEffect>()? 0.1f:0.2f;
            Player.GetDamage(DamageClass.Generic) -= AddDamage;
        }
    }

    public class MolluskGlobalProjectile : GlobalProjectile
    {

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            if (player.HasEffectEnchant<MolluskEnchantEffect>())
            {
                MolluskPlayer.AddDamage++;
                if(MolluskEnchantEffect.HitTime >= 180)
                {
                    player.GetDamage(DamageClass.Generic) -= MolluskPlayer.AddDamage;
                    MolluskPlayer.AddDamage = 0;
                }
                MolluskEnchantEffect.HitTime = 0;
            }
        }
    }
}
