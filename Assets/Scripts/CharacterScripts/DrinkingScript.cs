using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingScript : MonoBehaviour
{
    public float waterValue = 10;
    private bool canDrink;
    
    private GameObject player;
    private PlayerStatusScript playerData;
    
    void Start()
    {
        canDrink = false;    
        player = GameObject.Find("Player");
        playerData = player.GetComponent<PlayerStatusScript>();
    }

    void Update()
    {
        if(canDrink && Input.GetKeyDown(KeyCode.F))
        {
            Drink();
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            canDrink = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            canDrink = false;
        }
    }

    void Drink()
    {
        if(playerData.currentWater < playerData.maxWater)
        {
            playerData.currentWater = (playerData.currentWater + waterValue > playerData.maxWater) ? playerData.maxWater : playerData.currentWater + waterValue;
        }
    }
}
