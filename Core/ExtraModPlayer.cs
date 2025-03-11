using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Core;

public class ExtraModPlayer : ModPlayer
{
    
    public int HitTime = 0;
    public override void PostUpdate()
    {
        // 计算玩家命中间隔
        // 最多十秒
        // 在Core.ExtraGlobalProjectile中的OnHit处让击中时该值为0重新计算
        HitTime++;
        if(HitTime >= 600)
            HitTime = 600;
    }
}
