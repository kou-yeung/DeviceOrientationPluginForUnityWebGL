# DeviceOrientationPluginForUnityWebGL

DeviceOrientation Plguin For UnityWebGL

Unity WebGL用ジャイロセンサープラグイン

# How To Use
```
void Start ()
{
  DeviceOrientation.DeviceOrientationEvent += OnDeviceOrientationEvent;
}

void OnDeviceOrientationEvent(Vector3 v3)
{
  /// you can get device orientation in here
  /// when javascript call deviceorientation event
}
```

