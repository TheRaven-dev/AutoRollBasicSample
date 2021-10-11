using System;
using wManager.Wow.Helpers;

namespace AutoRoll.CustomWowItemHandler
{
    public class PurseRollItem
    {
        public String itemLink { get; set; }
        public String ItemName { get; set; }

        public PurseRollItem(String _ItemName, String _Itemlink)
        {
            this.itemLink = _Itemlink;
            this.ItemName = _ItemName;
        }

        public void pulse()
        {
            CreateFrame();
            Lua.LuaDoString($@"print(""trying to purse the item stats of {this.ItemName}"");
                            {AutoRollToolTip}:ClearLines();
                            {AutoRollToolTip}:SetHyperlink({this.itemLink});
                            for i = 1, {AutoRollToolTip}:NumLines() do
                                text = _G[""ItemRollLootStatTextLeft""..i]:GetText();
                                print(text);
                            end
                            print(""pursing of {this.ItemName} Completed."");");
        }

        private void CreateFrame()
        {
            Lua.LuaDoString($@"if not {AutoRollToolTip} then 
                                {AutoRollToolTip} = CreateFrame('GameTooltip', 'ItemRollLootStat', UIParent, 'GameTooltipTemplate') 
                                {AutoRollToolTip}:SetOwner(UIParent, 'ANCHOR_NONE');
                                print('{AutoRollToolTip} was created.')
                        end");
        }
        private static String AutoRollToolTip = "AutoRollToolTip";
    }
}
