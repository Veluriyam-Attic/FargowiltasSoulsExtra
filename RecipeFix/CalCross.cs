using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.RecipeFix;

public class CalRecipe
{
    [JITWhenModsEnabled("FargowiltasCrossmod")]
    public static void DLCChange(){
        for (int i = 0; i < Recipe.numRecipes; i++)
        {
            // 将DLC的勘探之力纳入到泰拉之魂的合成配方
            Recipe recipe = Main.recipe[i];
            if (recipe.HasResult<TerrariaSoul>() && !recipe.HasIngredient<ExplorationForce>())
            {
                recipe.AddIngredient<ExplorationForce>(1);
            }
        } 
    }
}
public class ChangeRecipe : ModSystem
{
    public override void PostAddRecipes()
    {
        if (ModLoader.HasMod("FargowiltasCrossmod"))
        {
            CalRecipe.DLCChange();
        }
    }
}