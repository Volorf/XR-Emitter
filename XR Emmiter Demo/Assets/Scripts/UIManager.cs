using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    private float _onTriggerIntensityValue;
    private bool _onTriggerPressedValue;
    private bool _onPrimaryButtonPressedValue;

    private string _consoleLog;
    private void Start()
    {
        XREmitterR.OnTriggerIntensity += SetOnTriggerIntensityValue;
        XREmitterR.OnTriggerPressed += SetOnTriggerPressedValue;
        XREmitterR.OnPrimaryButtonPressed += SetOnPrimaryButtonPressedValue;
    }

    private void SetOnTriggerIntensityValue(float f) { _onTriggerIntensityValue = f; }
    private void SetOnTriggerPressedValue(bool b) { _onTriggerPressedValue = b; }
    private void SetOnPrimaryButtonPressedValue(bool b) { _onPrimaryButtonPressedValue = b; }
    
    private void Update()
    {
        label.text = GetConsoleLogMessage();
    }

    private string GetConsoleLogMessage()
    {
        _consoleLog = "OnTriggerIntensity: " + Math.Round(_onTriggerIntensityValue, 3) + "\n" +
                      "OnTriggerPressed: " + _onTriggerPressedValue + "\n" +
                      "OnPrimaryButtonPressed: " + _onPrimaryButtonPressedValue + "\n";
        
        return _consoleLog;
    }
}
