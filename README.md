# XR Emitter
It's a simple events emitter on the top of Unity's XR Toolkit.

Right now XREmitter helps getting events from hand controllers.

<img src="images/placeholder.png" width="600">


# How to setup it
Assume that you already setup XR Toolkit and added XR Rig to your scene.

1. Import XREmitter.unityasset into your project; <img src="images/placeholder.png" width="600">

2. Add XREmitterR and/or XREmitterL components to Right/Left Controllers in your scene; <img src="images/placeholder.png" width="600">

3. Assign XRControllers to the components accordingly; <img src="images/placeholder.png" width="600">

4. Subscribe your method to an event stream (look at an example below).

# How to use it
Here is a little example how the XREmitter can be used. XREmitter's events are static, so you don't need  to 

```csharp
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private bool _lastTriggerButtonState = false;
    
    // Subsribe a method to an event stream
    private void OnEnable() 
    {
        XREmitterR.OnTriggerButtonPressed += SetBoxVisability;
    }

    // A good practice to unsubscribe a method when its object is gone
    private void OnDisable() 
    {
        XREmitterR.OnTriggerButtonPressed -= SetBoxVisability;
    }

    // The signature of the method the same as the event stream we want to subscribe it to.
    private void SetBoxVisability (bool b) 
    {
        if (_lastTriggerButtonState == b) return;
        _lastTriggerButtonState = b;

        this.transform.gameobject.SetActive(b);
    }
}
```
# Events List
``` <T> ``` defines a data type that is going to be passed to a subscribed method.
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

# Links