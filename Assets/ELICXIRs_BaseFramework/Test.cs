using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//デバッグ用の機能
public class Test
{
    public static bool ShowLog = true;
    public static bool ShowInputLog = true;

    public static void InputLog(object message)
    {
        if (ShowInputLog)
        {
            Debug.Log(message);
        }
    }
    public static void Log(object message)
    {
        if (ShowLog)
        {
            Debug.Log(message);
        }
    }
    public static void LogWarning(object message)
    {
        if (ShowLog)
        {
            Debug.LogWarning(message);
        }
    }
    public static void LogError(object message)
    {
        if (ShowLog)
        {
            Debug.LogError(message);
        }
    }
}
