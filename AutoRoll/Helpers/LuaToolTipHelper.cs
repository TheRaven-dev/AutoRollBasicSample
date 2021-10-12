using robotManager.Helpful;
using System;
using wManager.Wow.Helpers;
using wManager.Wow;
using System.Linq;

namespace AutoRoll.Helpers
{
    internal static class LuaToolTipHelper
    {
        public static void CreateFrame(String Context = "AutoRollToolTip")
        {
            Lua.LuaDoString($@"if not {Context} then 
                                    {Context} = CreateFrame('GameTooltip', 'ItemRollLootStat', UIParent, 'GameTooltipTemplate') 
                                    {Context}:SetOwner(UIParent, 'ANCHOR_NONE');
                                    print('{Context} was created.')
                                end");
        }

        public static String TestReader(int _RollNumber, String Context = "AutoRollToolTip")
        {
            Memory.WowMemory.LockFrame();
            LuaToolTipHelper.CreateFrame();
            try
            {
                return Lua.LuaDoString<String>($@"local RollItemlink = GetLootRollItemLink({_RollNumber});
                                                StatTable = {{'Strength' ,'Stamina', 'Spirit', 'Spell power', 'Agility', 'Intellect', 'Armor'}}
                                                {Context}:ClearLines();
                                                {Context}:SetHyperlink(RollItemlink);
                                                ItemName = ItemRollLootStatTextLeft1:GetText()
                                                for i = 1, {Context}:NumLines() do
                                                    text = _G['ItemRollLootStatTextLeft'..i]:GetText();
                                                    if string.find(text, StatTable[1]) then
                                                        StatTable[1] = tonumber(string.match(text, '%d+'));
                                                    end
                                                    if string.find(text, StatTable[2]) then
                                                        StatTable[2] = tonumber(string.match(text, '%d+'));
                                                    end
                                                     if string.find(text, StatTable[3]) then
                                                        StatTable[3] = tonumber(string.match(text, '%d+'));
                                                    end
                                                    if string.find(text, StatTable[4]) then
                                                        StatTable[4] = tonumber(string.match(text, '%d+'));
                                                    end
                                                     if string.find(text, StatTable[5]) then
                                                        StatTable[5] = tonumber(string.match(text, '%d+'));
                                                    end
                                                    if string.find(text, StatTable[6]) then
                                                        StatTable[6] = tonumber(string.match(text, '%d+'));
                                                    end
                                                    if string.find(text, StatTable[7]) then
                                                        StatTable[7] = tonumber(string.match(text, '%d+'));
                                                    end
                                                end
                                                return ItemName..';'..StatTable[1]..';'..StatTable[2]..';'..StatTable[3]..';'..StatTable[4] ..';'..StatTable[5] ..';'..StatTable[6] 
                                                ..';'..StatTable[7]");
            }
            finally
            {
                Memory.WowMemory.UnlockFrame();
            }
        }
    }
}


/* public static String ToolTipReader(String ItemLink, String Context = "AutoRollToolTip")
{
    //LuaToolTipHelper.CreateFrame();
    String results = null;
    Logging.Write(ItemLink);
    try
    {

        String GetItemStat = $@"local Intellect;
                                        {Context}:ClearLines();
                                        {Context}:SetHyperlink({ItemLink});
                                            print(ItemLink);
                                            for i = 1, {Context}:NumLines() do
                                                local text = _G[""ItemRollLootStatTextLeft""..i]:GetText();
                                                if string.find(text, 'Intellect') then
                                                        Intellect = tonumber(string.match(text, '%d+'));
                                                        break;
                                                 end
                                            end
                                            {Context}:Hide();
                                            --return ItemName ..'?'.. Intellect;
                                             return Intellect;";
        results = Lua.LuaDoString<String>(GetItemStat);

        Logging.Write(results);
    }
    catch
    {
        results = null;
    }
    return results;
}
*/