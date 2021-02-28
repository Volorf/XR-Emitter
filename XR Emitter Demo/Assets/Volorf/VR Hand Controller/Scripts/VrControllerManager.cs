using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrControllerManager : MonoBehaviour
{
    private VrController _vrController;

    private enum Hand
    {
        Left,
        Right
    }

    [SerializeField] private Hand currentHand = Hand.Right;
    
    private void Awake()
    {
        _vrController = GetComponent<VrController>();

        if (currentHand == Hand.Right)
        {

            XREmitterR.OnSecondaryButtonPressed += UpdateSecondaryButtonState;
            XREmitterR.OnPrimaryButtonPressed += UpdatePrimaryButtonState;
            XREmitterR.OnTriggerIntensity += UpdateTriggerButtonState;
            XREmitterR.OnGripIntensity += UpdateGripButtonState;
            XREmitterR.OnPrimary2DAxis += UpdateJoystickState; 
        }

        if (currentHand == Hand.Left)
        {
            XREmitterL.OnSecondaryButtonPressed += UpdateSecondaryButtonState;
            XREmitterL.OnPrimaryButtonPressed += UpdatePrimaryButtonState;
            XREmitterL.OnTriggerIntensity += UpdateTriggerButtonState;
            XREmitterL.OnGripIntensity += UpdateGripButtonState;
            XREmitterL.OnPrimary2DAxis += UpdateJoystickState; 
        }
    }

    
    private void UpdateSecondaryButtonState(bool value)
    {
        _vrController.SetSecondaryButtonState(value);
    }

    private void UpdatePrimaryButtonState(bool value)
    {
        _vrController.SetPrimaryButtonState(value);
    }

    private void UpdateTriggerButtonState(float value)
    {
        _vrController.SetTriggerButtonState(value);
    }

    private void UpdateGripButtonState(float value)
    {
        _vrController.SetGripButtonState(value);
    }

    private void UpdateJoystickState(Vector2 vector2)
    {
        _vrController.SetJoystickState(vector2);
    }
}
