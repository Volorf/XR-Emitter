using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;

    private float _onTriggerIntensityValue;

    private string _consoleLog;
    private void Start()
    {
        XREmitterR.OnTriggerIntensity += SetOnTriggerIntensityValue;
        
    }

    private void SetOnTriggerIntensityValue(float f)
    {
        _onTriggerIntensityValue = f;
    }
    
    private void Update()
    {
        if (_consoleLog == null)
        {
            label.text = "no XREmitter";
            return;
        }

        SetConsoleLogMessage();
        
        label.text = _consoleLog;
    }

    private void SetConsoleLogMessage()
    {
        _consoleLog = "OnTriggerIntensity: " + _onTriggerIntensityValue +
                      " ";
    }
}
