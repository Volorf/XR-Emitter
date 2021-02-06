# XR-Emitter
Simple XR controller events emitter on the top of Unity's XR Toolkit and based on the Observer Pattern.

Right now XREmitter helps getting events from hand controllers (left/right).

<img src="Images/demo2.gif" width="600">


# How to setup it
1. Add XREmitterR and/or XREmitterL prefabs to your scene;
2. Adde XRControllers to the prefabs;
3. Subscribe a needed method to an event scream (it has to have the same signature).

# How to use it
Here is a little example how the XREmitter can used.
Video is worsth 10000000 words, watch the YouTube video :)

```csharp
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private bool _lastTriggerButtonState = false;

    private void OnEnable() 
    {
        XREmitterR.OnTriggerButtonPressed += SetBoxVisability;
    }

    private void OnDisable() 
    {
        XREmitterR.OnTriggerButtonPressed -= SetBoxVisability;
    }

    private void SetBoxVisability (bool b) 
    {
        if (_lastTriggerButtonState == b) return;
        _lastTriggerButtonState = b;
        this.transform.gameobject.SetActive(b);
    }
}
```
# Events List
Remember that the method you subscribe to an event has to have the same signature that the event has.

```csharp
    public static event Action<float> OnTriggerIntensity;
    public static event Action<bool> OnTriggerButtonPressed;
    public static event Action<bool> OnPrimaryButtonPressed;
    public static event Action<bool> OnPrimaryButtonTouched;
    public static event Action<bool> OnSecondaryButtonPressed;
    public static event Action<bool> OnSecondaryButtonTouched;
    public static event Action<float> OnGripIntensity;
    public static event Action<bool> OnGripPressed;
    public static event Action<Vector2> OnPrimary2DAxis;
    public static event Action<bool> OnPrimary2DAxisPressed;
    public static event Action<bool> OnPrimary2DAxisTouched;
```

