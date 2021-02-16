using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private bool _lastTriggerButtonState = false;
    
    // Subscribe a method to an event stream
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

        this.gameObject.SetActive(b);
    }
}
