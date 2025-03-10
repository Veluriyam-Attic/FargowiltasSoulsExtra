using Terraria;
using Terraria.ModLoader;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSoulsDLC.Base.Items.Enchantments;

namespace FargowiltasSoulsExtra.RecipeFix;

public class AddEternityForce: ModSystem
{
    public override void PostAddRecipes()
    {
        // 将官方Extra的永恒之力添加到永恒之魂的配方中
        // 不要放到泰拉之魂
        // 或者搞个新魂，作为永恒之魂的材料
        for (int i = 0; i < Recipe.numRecipes; i++)
        {
            Recipe recipe = Main.recipe[i];
            if(recipe.HasResult<EternitySoul>() && !recipe.HasIngredient<EternitySoul>())
            {
                recipe.AddIngredient<EternityForce>(1);
            }
        }
    }
}