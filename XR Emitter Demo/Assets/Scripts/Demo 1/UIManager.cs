using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    private float _onTriggerIntensityValue;
    private bool _onTriggerPressedValue;
    private bool _onPrimaryButtonPressedValue;
    private bool _onPrimaryTouchedValue;
    private bool _onSecondaryButtonPressed;
    private bool _onSecondaryButtonTouched;
    private float _onGripIntensity;
    private bool _onGripPressed;
    private Vector2 _onPrimary2DAxis;
    private bool _onPrimary2DAxisPressed;
    private bool _onPrimary2DAxisTouched;

    private string _consoleLog;
    private void Start()
    {
        XREmitterR.OnTriggerIntensity += SetOnTriggerIntensityValue;
        XREmitterR.OnTriggerButtonPressed += SetOnTriggerButtonPressedValue;
        XREmitterR.OnPrimaryButtonPressed += SetOnPrimaryButtonPressedValue;
        XREmitterR.OnPrimaryButtonTouched += SetOnPrimaryButtonTouchedValue;
        XREmitterR.OnSecondaryButtonPressed += SetOnSecondaryButtonPressedValue;
        XREmitterR.OnSecondaryButtonTouched += SetOnSecondaryButtonTouchedValue;
        XREmitterR.OnGripIntensity += SetOnGripIntensityValue;
        XREmitterR.OnGripPressed += SetOnGripPressedValue;
        XREmitterR.OnPrimary2DAxis += SetOnPrimary2DAxisValue;
        XREmitterR.OnPrimary2DAxisPressed += SetOnPrimary2DAxisPressedValue;
        XREmitterR.OnPrimary2DAxisTouched += SetOnPrimary2DAxisTouchedValue;
    }

    private void SetOnTriggerIntensityValue(float f) { _onTriggerIntensityValue = f; }
    private void SetOnTriggerButtonPressedValue(bool b) { _onTriggerPressedValue = b; }
    private void SetOnPrimaryButtonPressedValue(bool b) { _onPrimaryButtonPressedValue = b; }
    private void SetOnPrimaryButtonTouchedValue(bool b) { _onPrimaryTouchedValue = b; }
    private void SetOnSecondaryButtonPressedValue(bool b) { _onSecondaryButtonPressed = b; }
    private void SetOnSecondaryButtonTouchedValue(bool b) { _onSecondaryButtonTouched = b; }
    private void SetOnGripIntensityValue(float f) { _onGripIntensity = f; }
    private void SetOnGripPressedValue(bool b) { _onGripPressed = b; }
    private void SetOnPrimary2DAxisValue(Vector2 v2) { _onPrimary2DAxis = v2; }
    private void SetOnPrimary2DAxisPressedValue(bool b) { _onPrimary2DAxisPressed = b; }
    private void SetOnPrimary2DAxisTouchedValue(bool b) { _onPrimary2DAxisTouched = b; }
    
    private void Update()
    {
        label.text = GetConsoleLogMessage();
    }

    private string GetConsoleLogMessage()
    {
        _consoleLog = "OnTriggerIntensity: " + Math.Round(_onTriggerIntensityValue, 3) + "\n" +
                      "OnTriggerPressed: " + _onTriggerPressedValue + "\n" +
                      "OnPrimaryButtonPressed: " + _onPrimaryButtonPressedValue + "\n" +
                      "OnPrimaryTouched: " + _onPrimaryTouchedValue + "\n" +
                      "OnSecondaryButtonPressed: " + _onSecondaryButtonPressed + "\n" +
                      "OnSecondaryButtonTouched: " + _onSecondaryButtonTouched + "\n" +
                      "OnGripIntensity: " + Math.Round(_onGripIntensity, 3) + "\n" +
                      "OnGripPressed: " + _onGripPressed + "\n" +
                      "OnPrimary2DAxis: " + _onPrimary2DAxis + "\n" +
                      "OnPrimary2DAxisPressed: " + _onPrimary2DAxisPressed + "\n" +
                      "OnPrimary2DAxisTouched: " + _onPrimary2DAxisTouched + "\n";
        
        return _consoleLog;
    }
}
