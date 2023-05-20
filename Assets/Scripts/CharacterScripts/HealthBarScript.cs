using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public PlayerStatusScript playerData;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }


        float fillValue = playerData.currentHealth / playerData.maxHealth;
        
        if (fillValue <= slider.maxValue / 5)
        {
            fillImage.color = Color.red;
        }
        else if (fillValue <= slider.maxValue / 2)
        {
            fillImage.color = Color.yellow;
        }
        else fillImage.color = Color.green;
        
        slider.value = fillValue;

    }
}
