using robotManager.Helpful;
using System;
using System.Collections.Generic;
using wManager.Wow.Helpers;

namespace AutoRoll.CustomWowItemHandler
{
    public static class BasicEventHook
    {
        private static PurseRollItem _PurseItem = null;
        public static void Start()
        {
            EventsLuaWithArgs.OnEventsLuaStringWithArgs += _GetitemLink;
        }

        public static void Stop()
        {
            EventsLuaWithArgs.OnEventsLuaStringWithArgs -= _GetitemLink;
        }

        private static void _GetitemLink(String LuaEvent, List<String> Args)
        {
            if (LuaEvent == "START_LOOT_ROLL")
            {
                String RollID = Args[0];
                String GetItemLinkFromRoll = Lua.LuaDoString<String>($"local RollItemlink = GetLootRollItemLink({RollID}); return RollItemlink;");
                String[] GetitemRollInfo = Lua.LuaDoString<String[]>($"local RollInfo = {{GetLootRollItemInfo({RollID})}}; return RollInfo;");
                Logging.Write($"ItemName = {GetitemRollInfo[0]} | ItemLink = {GetItemLinkFromRoll}");


                //Testing tooltip 
                _PurseItem = new PurseRollItem(GetitemRollInfo[0], GetItemLinkFromRoll);
                _PurseItem.pulse();
            }
        }
    }
}
