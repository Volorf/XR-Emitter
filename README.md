# XR Emitter
Simple XR controller events emitter on the top of Unity's XR Toolkit and based on the Observer Pattern.

Right now XREmitter helps getting events from hand controllers (left/right).

<img src="images/placeholder.png" width="600">


# How to setup it
1. Add XREmitterR and/or XREmitterL prefabs to your scene;

<img src="images/placeholder.png" width="600">

2. Add XRControllers to the prefabs;

<img src="images/placeholder.png" width="600">

3. Subscribe your method to an event stream (look at an example below).

# How to use it
Here is a little example how the XREmitter can be used.

```csharp
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private bool _lastTriggerButtonState = false;
    
    // Subsrice a method to an event stream
    private void OnEnable() 
    {
        XREmitterR.OnTriggerButtonPressed += SetBoxVisability;
    }

    // That's a general good practice to unsubscribe a method when its object is gone)
    private void OnDisable() 
    {
        XREmitterR.OnTriggerButtonPressed -= SetBoxVisability;
    }

    // The signature of the method the same as the event stream we are going to subscribe it to (it passed a bool value as a parameter).
    private void SetBoxVisability (bool b) 
    {
        // Switch to get the bool value only once when it changes
        if (_lastTriggerButtonState == b) return;
        _lastTriggerButtonState = b;

        // Set visability based on the bool value
        this.transform.gameobject.SetActive(b);
    }
}
```
# Events List
``` <T> ``` defines the data type that is going to be passed to a subscribed method. It defines a signature of the method.
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

