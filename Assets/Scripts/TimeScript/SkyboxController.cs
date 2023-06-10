using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SkyboxController : MonoBehaviour
{
    public Material sunSkyboxMaterial;
    public Material starsSkyboxMaterial;
    public float transitionDuration = 10f;

    private float transitionTimer;
    private Material currentSkyboxMaterial;
    private Material targetSkyboxMaterial;

    TimeController controller;
    void Start()
    {
        currentSkyboxMaterial = sunSkyboxMaterial;
        RenderSettings.skybox = currentSkyboxMaterial;
        controller = GameObject.Find("TimeControl").GetComponent<TimeController>();
    }

    void Update()
    {
        if((controller.currentHour <= 4) || controller.currentHour >= 19)
        {
        currentSkyboxMaterial = starsSkyboxMaterial;
        RenderSettings.skybox = currentSkyboxMaterial;
        }
        else 
        {
        currentSkyboxMaterial = sunSkyboxMaterial;
        RenderSettings.skybox = currentSkyboxMaterial;
        }    
        Debug.Log(controller.currentHour);
    }
}