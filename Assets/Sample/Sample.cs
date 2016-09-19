using UnityEngine;
using UnityEngine.UI;
using System;

public class Sample : MonoBehaviour {

    public Text text;

	void Start ()
    {
        DeviceOrientation.DeviceOrientationEvent += OnDeviceOrientationEvent;
    }

    void OnDeviceOrientationEvent(Vector3 v3)
    {
        transform.rotation = Quaternion.Euler(v3);
        text.text = String.Format("X({0})\nY({1})\nZ({2})", v3.x, v3.y, v3.z);
    }
}
