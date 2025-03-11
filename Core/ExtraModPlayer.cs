using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Enchantments;
using FargowiltasSoulsExtra.Items.Calamity.Enchantments.BHardmode;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Core;

public class ExtraModPlayer : ModPlayer
{
    
    public int HitTime = 0;

    public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if(Main.player[proj.owner] == Main.LocalPlayer)
        {
            // 让上次命中时间为0
            // Core.ExtraModPlayer中每帧计算
            Player player = Main.LocalPlayer;
            HitTime = 0;
        }
    }
    public override void PostUpdate()
    {
        // 计算玩家命中间隔
        // 最多十秒
        HitTime++;
        if(HitTime >= 600)
            HitTime = 600;
    }
}
