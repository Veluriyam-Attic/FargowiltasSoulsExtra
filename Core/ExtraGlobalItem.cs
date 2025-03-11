using System;
using System.Collections.Generic;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargowiltasSoulsExtra.Core;

public class WizardTooltipFix : GlobalItem
{
    // public override bool AppliesToEntity(Item entity, bool lateInstantiation) => (entity is ExtraBaseEnchant);
    // public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    // {
    //     if(item is ExtraBaseEnchant)
    //     {
    //         int num = tooltips.FindIndex(num => num.Name.Equals("wizard"));
    //         var line = (new TooltipLine(Mod, "ID"+nameof(Item), Language.GetTextValue("Mods.FargowiltasSoulsExtra.Item."+nameof(Item)+"WizardText")));
    //         tooltips.Insert(num, line);
    //         tooltips.Remove(tooltips[num]);
    //     }
    // }
    
}
