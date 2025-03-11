
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Core;

public class ExtraGlobalProjectile : GlobalProjectile
{
    public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if(Main.player[projectile.owner] == Main.LocalPlayer)
        {
            // 让上次命中时间为0
            // Core.ExtraModPlayer中每帧计算
            Player player = Main.LocalPlayer;
            player.GetModPlayer<ExtraModPlayer>().HitTime = 0;
        }
    }
}
