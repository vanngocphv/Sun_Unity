using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValueSceneUI : MonoBehaviour
{
    [Header("Get value from this Object")]
    [SerializeField] private SunLightningController _sunControllerGameObject;

    [Header("Change value scene")]
    [SerializeField] private GameObject _changeValueScene;

    [Header("Input Field Change")]
    [SerializeField] private TMP_InputField _latitude;
    [SerializeField] private TMP_InputField _longtitude;
    [SerializeField] private TMP_InputField _year;
    [SerializeField] private TMP_InputField _month;
    [SerializeField] private TMP_InputField _day;
    [SerializeField] private TMP_InputField _hour;
    [SerializeField] private TMP_InputField _minute;
    [SerializeField] private Button _ChangeValueButton;

    [Header("Warning UI")]
    [SerializeField] private Animator _warningAnimator;

    private const string _const_WARNINGTRIGGER = "WarningTrigger";

    private int _warningTriggerHash;


    private void Start()
    {
        InputManager.Instance.OnChangeValue += OnChangeValueClicked;

        _ChangeValueButton.onClick.AddListener(OnUpdateValue);

        _warningTriggerHash = Animator.StringToHash(_const_WARNINGTRIGGER);
    }


    private void OnChangeValueClicked(object sender, InputManager.OnChangeValueArgs e)
    {
        if (e.isTabClicked == true)
        {
            ShowGameObject();
        }
        else
        {
            HideGameObject();
        }
    }


    private void ShowGameObject()
    {
        SetInitialValue();
        _changeValueScene.gameObject.SetActive(true);
    }
    private void HideGameObject()
    {
        _changeValueScene.gameObject.SetActive(false);
    }

    private void SetInitialValue()
    {
        _latitude.text = _sunControllerGameObject.GetLatitude().ToString();
        _longtitude.text = _sunControllerGameObject.GetLongtitude().ToString(); 

        string date = _sunControllerGameObject.GetDate().ToString();
        string[] dateSplit = date.Split('/');
        _year.text = dateSplit[2];
        _month.text = dateSplit[1];
        _day.text = dateSplit[0];

        string time = _sunControllerGameObject.GetTime().ToString();
        string[] timeSplit = time.Split(" ");
        bool isEvening = timeSplit[1] == "PM" ? true : false;
        timeSplit = timeSplit[0].Split(":");

        int hours = int.Parse(timeSplit[0]);
        if (isEvening)
        {
            _hour.text = hours < 12f ? (hours + 12).ToString() : hours.ToString(); 
        }
        else
        {
            _hour.text = hours < 12f ? hours.ToString() : "00";
        }

        _minute.text = timeSplit[1];

    }

    private void OnUpdateValue()
    {
        //Check valid value
        bool isValid = IsValueValid();
        if (!isValid )
        {
            _warningAnimator.SetTrigger(_warningTriggerHash);
        }
        if (isValid)
        {
            UpdateValue();
            InputManager.Instance.HideAfterChange();
            HideGameObject();
        }
    }
    private bool IsValueValid()
    {
        try
        {
            float latitude = float.Parse(_latitude.text);
            float longtitude = float.Parse(_longtitude.text);
            int hours = int.Parse(_hour.text);
            int minutes = int.Parse(_minute.text);
            int day = int.Parse(_day.text);
            int month = int.Parse(_month.text);
            int year = int.Parse(_year.text);

            if (latitude > 90 || latitude < -90) return false;
            if (longtitude > 180 || longtitude < -180) return false;
            if (hours > 24 || hours < 0) return false;
            if (minutes > 60 || minutes < 0) return false;
            if (day < 0) return false;
            if (month > 12 || month < 0) return false;
            if (year > DateTime.Now.Year || year < 1700) return false;
        }
        catch
        {
            return false;
        }



        return true;
    }
    private void UpdateValue()
    {
        float latitude = float.Parse(_latitude.text);
        float longtitude = float.Parse(_longtitude.text);
        int hours = int.Parse(_hour.text);
        int minutes = int.Parse(_minute.text);
        int day = int.Parse(_day.text);
        int month = int.Parse(_month.text);
        int year = int.Parse(_year.text);

        _sunControllerGameObject.SetLatitude(latitude);
        _sunControllerGameObject.SetLongtitude(longtitude);
        _sunControllerGameObject.SetDate(year, month, day);
        _sunControllerGameObject.SetTime(hours, minutes);
        _sunControllerGameObject.UpdateCalculateForSun();
    }
}
