using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine;
using System;

public class XREmitterR : MonoBehaviour
{
    [SerializeField] private XRController xrController = null;

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

    private void Update()
    {
        if (xrController == null)
        {
            Debug.LogWarning("You did't add XR Controller to the script.");
            return;
        };
        
        // Trigger
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float intensity)) OnTriggerIntensity?.Invoke(intensity);
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed)) OnTriggerPressed?.Invoke(triggerPressed);
        
        // Joystick
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2Daxis)) OnPrimary2DAxis?.Invoke(primary2Daxis);
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primary2Dpressed)) OnPrimary2DAxisPressed?.Invoke(primary2Dpressed);
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool primary2DTouched)) OnPrimary2DAxisTouched?.Invoke(primary2DTouched);
        
        // Primary button
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonPressed)) OnPrimaryButtonPressed?.Invoke(primaryButtonPressed);
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched)) OnPrimaryTouched?.Invoke(primaryTouched);
        
        // Secondary button
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonPressed)) OnSecondaryButtonPressed?.Invoke(secondaryButtonPressed);
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched)) OnSecondaryTouched?.Invoke(secondaryTouched);
        
        // Grip
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripIntensity)) OnGripIntensity?.Invoke(gripIntensity);
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed)) OnGripPressed?.Invoke(gripPressed);
    }
}
