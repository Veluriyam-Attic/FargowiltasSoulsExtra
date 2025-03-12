using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.Armor.Mollusk;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Enchantments;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler;
using FargowiltasSoulsExtra.Core;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Items.Calamity.Enchantments.BHardmode
{
    // 软壳魔石
	public class MolluskEnchant : ExtraBaseEnchant
	{
		public override Color nameColor => new Color(248, 146, 248);

        // 是否启用DLC判定

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
            // 获得装备软壳魔石时的效果
            player.AddEffect<MolluskEnchantEffect>(Item);
        }

        // 配方锁，方便加载
        // 待完善

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

        // 给物品描述传值
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CalHardModeEnchantBalance.MolluskEnchantReduceSpeed,CalHardModeEnchantBalance.MolluskEnchantMaxAddDamage,CalHardModeEnchantBalance.MolluskEnchantAddDamageSpace,CalHardModeEnchantBalance.MolluskEnchantExtraReduceSpeed);
    }

    public class MolluskEnchantEffect : AccessoryEffect
    {
        // 在设置是否启用软壳魔石的效果页面归属
        // 待完善
        public override Header ToggleHeader => Header.GetHeader<EarthHeader>();
        public override void PostUpdateEquips(Player player)
        {
            // 忽略水
            player.ignoreWater = true;
			// 减速
            player.moveSpeed -= (CalHardModeEnchantBalance.MolluskEnchantReduceSpeed / 100);
            // 判断是否可以生效
            MolluskPlayer.CanAddDamage = true;

        }
    }

    public class MolluskPlayer : ModPlayer
    {
        // 加伤开关
        public static bool CanAddDamage = false;
        
        public override void ResetEffects()
        {
            // 如果可以加伤，则
            if(CanAddDamage)
            {
                // 如果一段时间未命中
                if(Player.GetModPlayer<ExtraModPlayer>().HitTime >= (60 * CalHardModeEnchantBalance.MolluskEnchantAddDamageSpace))
                {
                    // 加伤归为初始值
                    CalHardModeEnchantBalance.MolluskEnchantAddDamage = CalHardModeEnchantBalance.MolluskEnchantBaseAddDamage;
                }
                // 进行加伤
                Player.GetDamage(DamageClass.Generic) += CalHardModeEnchantBalance.MolluskEnchantAddDamage;
                // 进行额外的移速修改
                Player.moveSpeed -= Player.ForceEffect<MolluskEnchantEffect>()? (CalHardModeEnchantBalance.MolluskEnchantWizardSpeed / 100):(CalHardModeEnchantBalance.MolluskEnchantExtraReduceSpeed / 100);
                // 防止卸下饰品依旧有加上，在这关闭加伤
                CanAddDamage = false;
                // 结束方法，不知道必不必须
                return;
            }
            else
            {
                // 如果不能加伤，则将加伤归为初始值
                // 可以删去，删除后则卸下并在短时间内再次装备依旧有加伤
                CalHardModeEnchantBalance.MolluskEnchantAddDamage = CalHardModeEnchantBalance.MolluskEnchantBaseAddDamage;
            }
        }
    }

    public class MolluskGlobalProjectile : GlobalProjectile
    {
        // 当有弹幕击中NPC时
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.LocalPlayer;
            // 如果可以加伤开关打开&&弹幕源为当前玩家是
            if(MolluskPlayer.CanAddDamage && Main.LocalPlayer == Main.player[projectile.owner])
            {
                // 上次击中时间小于一定时间是
                if(player.GetModPlayer<ExtraModPlayer>().HitTime <= (60 * CalHardModeEnchantBalance.MolluskEnchantAddDamageSpace))
                {
                    // 如果加伤小于最大加伤
                    if(CalHardModeEnchantBalance.MolluskEnchantAddDamage < (CalHardModeEnchantBalance.MolluskEnchantMaxAddDamage / 100))
                    {
                        // 增加一层加伤数值
                        CalHardModeEnchantBalance.MolluskEnchantAddDamage += (CalHardModeEnchantBalance.MolluskEnchantStageAddDamage / 100);
                    }
                    // 如果加伤大于等于最大加伤
                    if(CalHardModeEnchantBalance.MolluskEnchantAddDamage >= (CalHardModeEnchantBalance.MolluskEnchantMaxAddDamage / 100))
                    {
                        // 让加伤值变为最大加伤
                        CalHardModeEnchantBalance.MolluskEnchantAddDamage = (CalHardModeEnchantBalance.MolluskEnchantMaxAddDamage / 100);
                    }
                    // 测试攻击间隔用
                    // Main.NewText(player.GetModPlayer<ExtraModPlayer>().HitTime);
                }
                // 如果加伤开关关闭或弹幕源不是玩家
                else
                {
                    // 让加伤归为基础加伤
                    CalHardModeEnchantBalance.MolluskEnchantAddDamage = CalHardModeEnchantBalance.MolluskEnchantBaseAddDamage;
                }
            }
        }
    }
}
