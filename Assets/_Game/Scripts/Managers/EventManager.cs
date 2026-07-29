using System;

public static class EventManager
{
    public static Action<int> OnLevelChanged;

    public static Action<float, float> OnXPChanged;

    public static Action<float, float> OnHealthChanged;

    public static Action<float> OnWaveTimerChanged;
}