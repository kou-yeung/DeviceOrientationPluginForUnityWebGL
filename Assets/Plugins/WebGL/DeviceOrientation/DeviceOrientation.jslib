//=====================================================
// JavaScript DeviceOrientation Plugin for UnityWebGL
//=====================================================

var LibraryDeviceOrientation = {
    $DeviceOrientation: {
        callback: null,
        initialed: false,
        Init: function () {
            if (DeviceOrientation.initialed) return;
            DeviceOrientation.initialed = true;
            window.addEventListener("deviceorientation", DeviceOrientation.OnDeviceorientation);
        },
        OnDeviceorientation: function (e) {
            var beta = e.beta;      // X
            var gamma = e.gamma;    // Y
            var alpha = e.alpha;    // Z
			if(DeviceOrientation.callback != null)
			{
				Runtime.dynCall('vddd', DeviceOrientation.callback, [beta, gamma, alpha]);
			}
        }
    },
    // Add Event Callback
    DeviceOrientationAddEvent: function (cb) {
        DeviceOrientation.Init();
        DeviceOrientation.callback = cb;
    },
};
autoAddDeps(LibraryDeviceOrientation, '$DeviceOrientation');
mergeInto(LibraryManager.library, LibraryDeviceOrientation);
