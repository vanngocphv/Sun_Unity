using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueHandleUI : MonoBehaviour
{
    [Header("Object has value")]
    [SerializeField] private SunLightningController _sunControllerObject;
    [Header("Value can changing")]
    [SerializeField] private TextMeshProUGUI _latitudeTMP;
    [SerializeField] private TextMeshProUGUI _longtitudeTMP;
    [SerializeField] private TextMeshProUGUI _dateTMP;
    [SerializeField] private TextMeshProUGUI _timeTMP;
    [SerializeField] private TextMeshProUGUI _sunAltitude;
    [SerializeField] private TextMeshProUGUI _sunAzimuth;

    private void Start()
    {
        UpdateTextMeshProValue();
    }

    private void Update()
    {
        if (_latitudeTMP.text != _sunControllerObject.GetLatitude().ToString()
            || _longtitudeTMP.text != _sunControllerObject.GetLongtitude().ToString()
            || _dateTMP.text != _sunControllerObject.GetDate()
            || _timeTMP.text != _sunControllerObject.GetTime()
            || _sunAltitude.text != _sunControllerObject.GetSunAltitude()
            || _sunAzimuth.text != _sunControllerObject.GetSunAzimuth())
        {
            UpdateTextMeshProValue();
        }
    }


    private void UpdateTextMeshProValue()
    {
        _latitudeTMP.text = _sunControllerObject.GetLatitude().ToString();
        _longtitudeTMP.text = _sunControllerObject.GetLongtitude().ToString();
        _dateTMP.text = _sunControllerObject.GetDate();
        _timeTMP.text = _sunControllerObject.GetTime();
        _sunAltitude.text = _sunControllerObject.GetSunAltitude();
        _sunAzimuth.text = _sunControllerObject.GetSunAzimuth();

    }
}
