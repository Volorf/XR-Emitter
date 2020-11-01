using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine;
using System;

public class XREmitterL :MonoBehaviour
{
    [SerializeField] XRController _controller = null;
    private bool _isControllerNotNull;

    public static event Action<float> OnTriggerIntensity;
    public static event Action<bool> OnTriggerPressed;

    public static event Action<bool> OnPrimaryButtonPressed;
    public static event Action<bool> OnPrimaryTouched;

    public static event Action<bool> OnSecondaryButtonPressed;
    public static event Action<bool> OnSecondaryTouched;

    public static event Action<float> OnGripIntensity;
    public static event Action<bool> OnGripPressed;

    public static event Action<Vector2> OnPrimary2DAxis;
    public static event Action<bool> OnPrimary2DAxisPressed;
    public static event Action<bool> OnPrimary2DAxisTouched;

    private void Start()
    {
        _isControllerNotNull = _controller != null;
    }

    private void Update()
    {
        if (!_isControllerNotNull) return;
        
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float intensity)) OnTriggerIntensity?.Invoke(intensity);
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed)) OnTriggerPressed?.Invoke(triggerPressed);

        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2Daxis)) OnPrimary2DAxis?.Invoke(primary2Daxis);
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primary2Dpressed)) OnPrimary2DAxisPressed?.Invoke(primary2Dpressed);
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool primary2DTouched)) OnPrimary2DAxisTouched?.Invoke(primary2DTouched);

        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonPressed)) OnPrimaryButtonPressed?.Invoke(primaryButtonPressed);
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched)) OnPrimaryTouched?.Invoke(primaryTouched);

        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonPressed)) OnSecondaryButtonPressed?.Invoke(secondaryButtonPressed);
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched)) OnSecondaryTouched?.Invoke(secondaryTouched);

        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripIntensity)) OnGripIntensity?.Invoke(gripIntensity);
        if (_controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed)) OnGripPressed?.Invoke(gripPressed);
    }
}
