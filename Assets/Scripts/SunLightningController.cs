using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoordinateSharp;
using System.Runtime.CompilerServices;

public class SunLightningController : MonoBehaviour
{
    [Header("Latitude, Longtitude")]
    [SerializeField] private float _latitude;
    [SerializeField] private float _longtitude;
    [Header("Date & time in UTC + 0")]
    [SerializeField] private int _year;
    [SerializeField] private int _month;
    [SerializeField] private int _day;
    [SerializeField] private int _hours;
    [SerializeField] private int _minutes;

    [Header("Lightning")]
    [SerializeField] private Light _theSun;
    [SerializeField] private float _sunIntensity = 3f;

    private const float _YrotateIn = 180f; //Z axis, -z axis = 0, -x axis = 90, z axis = 180, x axis = 270

    private float _sunCurrentAzimuth;
    private float _rotationX;
    private string _currentAltitude = "";
    private string _currentAzimuth = "";

    private void Awake(){
        CalculateAndRotateSun();
    }

    private void Start()
    {
        InputManager.Instance.OnUptime += OnUpTime;
        InputManager.Instance.OnDownTime += OnDownTime;
    }

    private void Update()
    {
        
    }


    private void CalculateAndRotateSun()
    {
        DateTime dateTime = new DateTime(_year, _month, _day, _hours, _minutes, 0);
        DateTime date = new DateTime(_year, _month, _day, 0, 0, 0);

        SunPositionCalculate(dateTime, date, _latitude, _longtitude, _hours);

        _theSun.transform.localEulerAngles = new Vector3(_rotationX, _sunCurrentAzimuth, 0);
    }

    private void SunPositionCalculate(DateTime dateTime, DateTime date, float latitude, float longtitude, float hours){

        Celestial cel = Celestial.CalculateCelestialTimes(latitude, longtitude, dateTime);
        double _altitude = cel.SunAltitude;        //chieu cao
        double _azimuth = cel.SunAzimuth;          //do nghien so voi truc Z (global)
        _currentAltitude = cel.SunAltitude.ToString(".0");
        _currentAzimuth = cel.SunAzimuth.ToString(".0");

        var sa = Celestial.Get_Time_at_Solar_Altitude(latitude, longtitude, date, cel.SunAltitude);


        if (CompareTime(dateTime, sa.Rising))
        {
            _rotationX = (float)_altitude;
        }
        else if (CompareTime(dateTime, sa.Setting))
        {
            _rotationX = (float)(180 - _altitude);
        }
        if (_altitude < 0)
        {
            //turn of the light
            _theSun.intensity = 0;
        }
        else _theSun.intensity = _sunIntensity;

        if (_azimuth < 180) _azimuth += 180f;
        //else if (_azimuth < -180f) _azimuth += 180f;
        _sunCurrentAzimuth = (float) (_azimuth);

        
    }

    private bool CompareTime(DateTime time1, DateTime? time2)
    {
        DateTime tmpTime = new DateTime();
        if (time2 != null) tmpTime = (DateTime) time2;
        int hours1 = time1.Hour;
        int minutes1 = time1.Minute;
        int hours2 = tmpTime.Hour;
        int minutes2 = tmpTime.Minute;

        if (hours1 == hours2)
        {
            if (minutes1 == minutes2 + 1 || minutes1 + 1 == minutes2)
            {
                return true;
            }
        }
        return false;
    }

    private void OnUpTime(object sender, System.EventArgs e) 
    {
        int hours = _hours + 1;
        int day = _day;
        if (hours >= 24)
        {
            hours = hours % 24;
            day += 1;
        }
        _hours = hours;
        _day = day;
        CalculateAndRotateSun();
    }
    private void OnDownTime(object sender, System.EventArgs e)
    {
        int hours = _hours - 1;
        int day = _day;
        if (hours < 0)
        {
            hours = 24 + hours;
            day -= 1;
        }
        _hours = hours;
        _day = day;
        CalculateAndRotateSun();
    }


    //public method
    //latitude
    public float GetLatitude()
    {
        return _latitude;
    }
    public void SetLatitude(float latitude)
    {
        _latitude = latitude;
    }

    //longtitude
    public float GetLongtitude()
    {
        return _longtitude;
    }
    public void SetLongtitude(float longtitude)
    {
        _longtitude = longtitude;
    }

    //date
    public string GetDate()
    {
        DateTime date = new DateTime(_year, _month, _day, 0, 0, 0);
        
        return date.ToString("dd/MM/yyyy");
    }
    public void SetDate(int year, int month, int day)
    {
        _year = year;
        _month = month;
        _day = day;
    }

    //Time
    public string GetTime()
    {
        DateTime dateTime = new DateTime(_year, _month, _day, _hours, _minutes, 0);
        return dateTime.ToShortTimeString();
    }
    public void SetTime(int hours, int minutes)
    {
        _hours = hours;
        _minutes = minutes;
    }

    //Sun value
    public string GetSunAltitude()
    {
        
        return _currentAltitude;
    }
    public string GetSunAzimuth()
    {
        
        return _currentAzimuth;
    }

    //Update the calculate to the sun
    public void UpdateCalculateForSun()
    {
        CalculateAndRotateSun();
    }

}
