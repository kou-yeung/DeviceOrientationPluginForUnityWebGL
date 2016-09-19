using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class DeviceOrientation
{
    [DllImport("__Internal")]
    static extern void DeviceOrientationAddEvent(Action<double, double, double> action);

    /// <summary>
    /// 静的コンストラクタ
    /// JavaScript にイベント登録用
    /// </summary>
    static DeviceOrientation()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // イベント登録
        DeviceOrientationAddEvent(EventCallback);
#endif
    }

    /// <summary>
    /// JavaScript -> C# 用コールバックイベント
    /// </summary>
    /// <param name="x">X軸</param>
    /// <param name="y">Y軸</param>
    /// <param name="z">Z軸</param>
    [MonoPInvokeCallback(typeof(Action<double, double, double>))]
    static void EventCallback(double x, double y, double z)
    {
        var vec3 = new Vector3((float)x, (float)y, (float)z);
        if (DeviceOrientationEvent != null)
        {
            DeviceOrientationEvent(vec3);
        }
    }

    static public Action<Vector3> DeviceOrientationEvent;
}
