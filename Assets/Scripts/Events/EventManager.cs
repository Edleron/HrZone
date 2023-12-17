using System;

public class EventManager
{
    public static event Action<string> onGameTriggerEnter;
    public static void Fire_onGameTriggerEnter(string value) { onGameTriggerEnter?.Invoke(value); }

    public static event Action<string> onGameTriggerExit;
    public static void Fire_onGameTriggerExit(string value) { onGameTriggerExit?.Invoke(value); }
}
