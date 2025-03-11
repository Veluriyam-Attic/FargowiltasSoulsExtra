using System.Security.Cryptography.X509Certificates;
using CalamityMod.Items.Armor.Mollusk;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Enchantments;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSoulsExtra.Core;
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
        public static int AddDamage = 0;
        public override Header ToggleHeader => Header.GetHeader<EarthHeader>();
        public override void PostUpdateEquips(Player player)
        {
            // 忽略水
            player.ignoreWater = true;
			// 减20%速度，巫师魔石减10%
            player.moveSpeed -= player.ForceEffect<MolluskEnchantEffect>()? 0.1f:0.2f;
        }
    }

    public class MolluskPlayer : ModPlayer{
        public override void ResetEffects()
        {
            if(Player.HasEffectEnchant<MolluskEnchantEffect>() && ExtraGlobalProjectile.HitTime <=180 && 0 < ExtraGlobalProjectile.HitTime)
            {
                Player.GetDamage(DamageClass.Generic) -= MolluskEnchantEffect.AddDamage;
                Player.moveSpeed += Player.ForceEffect<MolluskEnchantEffect>()? 0.1f:0.2f;
                Player.GetDamage(DamageClass.Generic) += MolluskEnchantEffect.AddDamage;
            }
            else if(Player.HasEffectEnchant<MolluskEnchantEffect>() && ExtraGlobalProjectile.HitTime  > 180)
                Player.GetDamage(DamageClass.Generic) -= MolluskEnchantEffect.AddDamage;
                MolluskEnchantEffect.AddDamage = 0;
        }
    }

    public class MolluskGlobalProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            if (player.HasEffectEnchant<MolluskEnchantEffect>() && Main.player[projectile.owner] == Main.LocalPlayer)
            {
                if(MolluskEnchantEffect.AddDamage < 20)
                    MolluskEnchantEffect.AddDamage++;
                else if(MolluskEnchantEffect.AddDamage == 20)
                    MolluskEnchantEffect.AddDamage = 20;
            }
        }
    }
}
