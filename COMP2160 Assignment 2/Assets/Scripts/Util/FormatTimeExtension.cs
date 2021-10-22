using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class FormatTimeExtension
{
    public static string FormatTime(float time) 
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);

        return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }
}
