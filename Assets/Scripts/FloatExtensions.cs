using UnityEngine;

public static class FloatExtensions
{
    public static float Abs(this float value)
    {
        return Mathf.Abs(value);
    }

    public static int RoundToInt(this float value)
    {
        return Mathf.RoundToInt(value);
    }
}