using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Core;

public class ExtraModPlayer : ModPlayer
{
    public override void PreUpdate()
    {
        // 计算玩家命中间隔
        // 最多十秒
        // 在Core.ExtraGlobalProjectile中的OnHit处让击中时该值为0重新计算
        ExtraGlobalProjectile.HitTime++;
        if(ExtraGlobalProjectile.HitTime >= 6000)
            ExtraGlobalProjectile.HitTime = 6000;
    }
}
