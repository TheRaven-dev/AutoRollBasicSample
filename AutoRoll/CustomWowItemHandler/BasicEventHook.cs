using robotManager.Helpful;
using System;
using System.Collections.Generic;
using wManager.Wow.Helpers;

namespace AutoRoll.CustomWowItemHandler
{
    public static class BasicEventHook
    {
        public static PurseRollItem _PurseItem = null;
        public static void Start()
        {
            EventsLuaWithArgs.OnEventsLuaStringWithArgs += _GetitemLink;
        }

        public static void Stop()
        {
            EventsLuaWithArgs.OnEventsLuaStringWithArgs -= _GetitemLink;
        }

        private static void _GetitemLink(string LuaEvent, List<string> Args)
        {
            if (LuaEvent == "START_LOOT_ROLL")
            {
                _PurseItem = new PurseRollItem(int.Parse(Args[0]));
                _PurseItem.DebugPrint();

            }
        }
    }
}
//fix bug later 
////String GetItemLinkFromRoll = Lua.LuaDoString<String>($"local RollItemlink = GetLootRollItemLink({RollID}); return RollItemlink;");
// _PurseItem = new PurseRollItem(GetItemLinkFromRoll);