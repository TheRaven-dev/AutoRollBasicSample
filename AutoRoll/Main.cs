using AutoRoll.CustomWowItemHandler;
using System;
using wManager.Plugin;

public class Main : IPlugin
{

    public void Initialize()
    {
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
