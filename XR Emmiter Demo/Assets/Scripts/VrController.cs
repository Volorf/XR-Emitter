using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrController : MonoBehaviour
{
    
    
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRendererRightController;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRendererLeftController;

    private SkinnedMeshRenderer _currentSkinnedMeshRenderer;
    
    private enum Hand
    {
        Left,
        Right
    }

    [SerializeField] private Hand currentHand = Hand.Right;
 
    private const int SECONDARY_BUTTON_INDEX = 0;
    [Range(0f, 100f)] [SerializeField] float secondaryButtonWeight = 0f;

    private const int PRIMARY_BUTTON_INDEX = 1;
    [Range(0f, 100f)] [SerializeField] float primaryButtonWeight = 0f;
    
    private const int TRIGGER_BUTTON_INDEX = 2;
    [Range(0f, 100f)] [SerializeField] float triggerButtonWeight = 0f;
    
    private const int GRIP_BUTTON_INDEX = 3;
    [Range(0f, 100f)] [SerializeField] float gripButtonWeight = 0f;

    [SerializeField] private bool testMode = false;
    private const float BLEND_SHAPE_MULTIPLIER = 100f;

    [SerializeField] private GameObject joystick;
    private const float X_OFFSET = 20f;
    private const float Y_OFFSET = 20f;
    
    public Vector2 vec2 = new Vector2(0f, 0f);

    private void Awake()
    {
        if (currentHand == Hand.Right)
        {
            _currentSkinnedMeshRenderer = skinnedMeshRendererRightController;
            skinnedMeshRendererLeftController.gameObject.SetActive(false);
        }

        if (currentHand == Hand.Left)
        {
            _currentSkinnedMeshRenderer = skinnedMeshRendererLeftController;
            joystick.transform.position += new Vector3(-transform.localScale.x, 0f, 0f);
            skinnedMeshRendererRightController.gameObject.SetActive(false);
            
        }
    }

    private void Update()
    {
        if (!testMode) return;
        _currentSkinnedMeshRenderer.SetBlendShapeWeight(SECONDARY_BUTTON_INDEX, secondaryButtonWeight);
        _currentSkinnedMeshRenderer.SetBlendShapeWeight(PRIMARY_BUTTON_INDEX, primaryButtonWeight);
        _currentSkinnedMeshRenderer.SetBlendShapeWeight(TRIGGER_BUTTON_INDEX, triggerButtonWeight);
        _currentSkinnedMeshRenderer.SetBlendShapeWeight(GRIP_BUTTON_INDEX, gripButtonWeight);
        SetJoystickState(vec2);
    }

    public void SetJoystickState(Vector2 vector2)
    {
        float zRot = vector2.x.Remap(-1f, 1f, X_OFFSET, -X_OFFSET);
        float xRot = vector2.y.Remap(-1f, 1f, -Y_OFFSET, Y_OFFSET);
        joystick.transform.localEulerAngles = (new Vector3(xRot, 0f, zRot));
    }
    
    public void SetSecondaryButtonState(bool value)
    {
        float processedValue = value ? BLEND_SHAPE_MULTIPLIER : 0f;
        ProcessButtonState(SECONDARY_BUTTON_INDEX, processedValue);
    }

    public void SetPrimaryButtonState(bool value)
    {
        float processedValue = value ? BLEND_SHAPE_MULTIPLIER : 0f;
        ProcessButtonState(PRIMARY_BUTTON_INDEX, processedValue);
    }

    public void SetTriggerButtonState(float value) => ProcessButtonState(TRIGGER_BUTTON_INDEX, value);
    public void SetGripButtonState(float value) => ProcessButtonState(GRIP_BUTTON_INDEX, value);

    private void ProcessButtonState(int index, float value)
    {
        float clampedValue = Mathf.Clamp(value * BLEND_SHAPE_MULTIPLIER, 0f, BLEND_SHAPE_MULTIPLIER);
        _currentSkinnedMeshRenderer.SetBlendShapeWeight(index, clampedValue);
    }
}
