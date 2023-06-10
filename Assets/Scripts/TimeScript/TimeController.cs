using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private float secondsInFullDay = 120f;

    [Range(0,1)] [SerializeField] public float currentTimeOfDay = 0;

    [Range(0,23)]
    [SerializeField] public int currentHour = 0;
    [Range(0,60)]
    [SerializeField] public int currentMinute = 0;

    private float timeMultiplier = 1f;
    private float sunInitialIntensity;

    // Start is called before the first frame update
    void Start()
    {
        sunInitialIntensity = sun.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if(currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }

        float _currentHour = 24 * currentTimeOfDay;
        float _currentMinute = 60 * (_currentHour - Mathf.Floor(_currentHour));

        currentHour = (int)_currentHour;
        currentMinute = (int)_currentMinute;


        if((currentHour <= 5) || currentHour >= 18)
        {
        RenderSettings.fog = false;
        } else 
        {
        RenderSettings.fog = true;
        }    
    }

    private void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 267 , 191);

        float intensityMultiplier = 1;

        if(currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if(currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1/0.02f));
        }

        else if(currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1/ 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }  
}
