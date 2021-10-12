using AutoRoll.CustomWowItemHandler;
using AutoRoll.Helpers;
using System;
using wManager.Plugin;

public class Main : IPlugin
{

    public void Initialize()
    {
        LuaToolTipHelper.CreateFrame();
        BasicEventHook.Start();
    }

    public void Settings()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        BasicEventHook.Stop();
    }
}
