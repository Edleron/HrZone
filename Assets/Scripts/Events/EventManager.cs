using System;

public class EventManager
{
    public static event Action<string> onGameTriggerEnter;
    public static void Fire_onGameTriggerEnter(string value) { onGameTriggerEnter?.Invoke(value); }

    public static event Action<string> onGameTriggerExit;
    public static void Fire_onGameTriggerExit(string value) { onGameTriggerExit?.Invoke(value); }


    public static event Action<string> UITriggerOpen;
    public static void Fire_UITriggerOpen(string value) { UITriggerOpen?.Invoke(value); }

    public static event Action<string> UITriggerClosed;
    public static void Fire_UITriggerClosed(string value) { UITriggerClosed?.Invoke(value); }


    public static event Action onLevelProcess;
    public static void Fire_onLevelProcess() { onLevelProcess?.Invoke(); }
}
