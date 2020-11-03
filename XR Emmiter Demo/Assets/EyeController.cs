using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    
    private void Start()
    {
        XREmitterR.OnTriggerIntensity += BlinkEye;
        XREmitterR.OnPrimary2DAxis += MoveEye;
    }

    private void BlinkEye(float openness)
    {
        
    }

    private void MoveEye(Vector2 moving)
    {
        
    }
    private void Update()
    {
        
    }
}
