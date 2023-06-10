using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusScript : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxWater = 100;
    public float currentWater = 100;
    public float currentHealth = 100;

    public float hungerInterval = 1f;
    public float hungerDecreaseAmount = 1;
    public float waterInterval = 1f;
    public float waterDecreaseAmount = 1;
    private float dehydration;
    
    private float hungerTimer;
    private float waterTimer;

    void Start()
    {
      hungerTimer = hungerInterval;
      waterTimer = waterInterval; 
    }

    void Update()
    {
        hungerTimer -= Time.deltaTime;
        waterTimer -= Time.deltaTime;

        currentWater = (currentWater < 0) ? 0 : currentWater;
        dehydration = (currentWater <= 0) ? 50 : 1;

        if(hungerTimer <= 0f)
        {
           DecreaseStat(ref currentHealth, hungerDecreaseAmount);
           hungerTimer = hungerInterval;
        }
 
        if(waterTimer <= 0f)
        {
           DecreaseStat(ref currentWater, waterDecreaseAmount * dehydration);
           waterTimer = waterInterval;
        }

        if(currentHealth <=0)
        {
            Debug.Log("Player is dead");
        }
        
    }

    void DecreaseStat(ref float stat, float amount)
    {
        stat -= amount;
    }
}
