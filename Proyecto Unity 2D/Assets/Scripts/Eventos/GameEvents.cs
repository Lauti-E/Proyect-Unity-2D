using System;

public static class GameEvents
{
    public static event Action EnPausa;
    public static event Action EnPlay;

    public static void TriggerPause() => EnPausa?.Invoke();

    public static void TriggerResume() => EnPlay?.Invoke();
}
