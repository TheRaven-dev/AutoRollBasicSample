using AutoRoll.Helpers;
using robotManager.Helpful;
using System;
using wManager.Wow.Helpers;

namespace AutoRoll.CustomWowItemHandler
{
    public class PurseRollItem
    {
        public String ItemLink { get; set; }
        public String ItemName { get; set; }
        public Int32 RollID { get; set; }


        public float Strength { get; set; }
        public float Stamina { get; set; } 
        public float Spirit { get; set; } 
        public float SpellPower { get; set; } 
        public float Agility { get; set; } 
        public float Intellect { get; set; } 
        public float Armor { get; set; }

        public PurseRollItem(Int32 _RollID)
        {
            String[] GetItemToolTipPulse = LuaToolTipHelper.TestReader(_RollID).Split(';');
            this.ItemName = GetItemToolTipPulse[0];
            this.Strength = ItemHelpers.TryPurse(GetItemToolTipPulse[1]);
            this.Stamina = ItemHelpers.TryPurse(GetItemToolTipPulse[2]);
            this.Spirit = ItemHelpers.TryPurse(GetItemToolTipPulse[3]);
            this.SpellPower = ItemHelpers.TryPurse(GetItemToolTipPulse[4]);
            this.Agility = ItemHelpers.TryPurse(GetItemToolTipPulse[5]);
            this.Intellect = ItemHelpers.TryPurse(GetItemToolTipPulse[6]);
        }
        public PurseRollItem(String _Itemlink)
        {
            //LuaToolTipHelper.TestReader(_Itemlink);

            //String[] itemInfo = LuaToolTipHelper.ToolTipReader(_Itemlink).Split(';');
            //this.ItemName = itemInfo[0];
            //this.Intellect = float.Parse(itemInfo[1]);
        }

        public void pulse()
        {

        }

        public void DebugPrint()
        {
            Logging.Write($"Item Pursing" + Environment.NewLine + 
                          $"ItenName = " + this.ItemName + Environment.NewLine +
                          $"Strength = " + this.Stamina + Environment.NewLine +
                          $"Stamina = " + this.Stamina + Environment.NewLine +
                          $"Spirit = " + this.Spirit + Environment.NewLine +
                          $"SpellPower " + this.SpellPower + Environment.NewLine +
                          $"Agility = " + this.Agility + Environment.NewLine +
                          $"Intellect = " + this.Intellect + Environment.NewLine +
                          $"Armor = " + this.Armor + Environment.NewLine +
                          $"Item Pursing ended" + Environment.NewLine
                          );
        }
    }
}
