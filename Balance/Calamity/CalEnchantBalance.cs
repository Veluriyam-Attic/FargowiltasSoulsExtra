global using FargowiltasSoulsExtra.Balance.Calamity;
namespace FargowiltasSoulsExtra.Balance.Calamity;

public class CalHardModeEnchantBalance
{
    // 值前面标float为小数,数字结尾尽量加个f
    // 值前面标int为整数

    #region 软壳魔石
    public static float MolluskEnchantBaseAddDamage = 0f;
    public static float MolluskEnchantAddDamage = 0f;
    // 软壳魔石：加伤初始值，默认为0即第一次命中加伤数为分段加伤值
    // 软壳魔石：若该值不为0则常态加伤
    // 软壳魔石：修改请谨慎，因为这需要同时修改本地化文件
    // 软壳魔石：上面这个值为每次取消加伤时复位的值
    // 软壳魔石：下面这个值为最开始的开始加伤时候的值
    // 软壳魔石：请保持一致，否则需要修改本地化文件
    public static int MolluskEnchantAddDamageSpace = 3;
    // 软壳魔石：该时间（秒）内不继续命中则取消该伤害加成
    public static float MolluskEnchantMaxAddDamage = 18f;
    // 软壳魔石：连续命中时最大加伤，单位为1%
    public static float MolluskEnchantStageAddDamage = 0.9f;
    // 软壳魔石：连续命中时每次增加的伤害，单位为1%
    // 软壳魔石：总加伤次数等于最大值除以这个值
    // 软壳魔石：尽量保证总加伤次数是整数
    public static float MolluskEnchantReduceSpeed = 7f;
    // 软壳魔石：这是默认减速的数值，单位1%
    public static float MolluskEnchantExtraReduceSpeed = 7f;
    // 软壳魔石：这是移动时额外减少的速度，单位1%
    public static float MolluskEnchantWizardSpeed = 0f;
    // 软壳魔石：这是使用巫师魔石下移动时额外减速的数值，单位1%
    // 软壳魔石：这个变动需要修改巫师魔石升级描述
    // 软壳魔石：待完善
    #endregion
}
