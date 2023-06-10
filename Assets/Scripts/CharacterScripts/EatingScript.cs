using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EatingScript : MonoBehaviour
{
   
    public float foodValue;
    private bool hasFood; 
    private bool canEat;
    

    private GameObject player;
    private PlayerStatusScript playerData;
    private DateTime lastEaten;
    void Start()
    {
        hasFood = true;     
        canEat = false;
        player = GameObject.Find("Player");
        playerData = player.GetComponent<PlayerStatusScript>();

   }

    void Update()
    {
       if(hasFood && canEat && Input.GetKeyDown(KeyCode.F))
       {
            Eat();
            hasFood = false;
            lastEaten = DateTime.Now;
       } 
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if((DateTime.Now - lastEaten).TotalSeconds >= 16)
            {
               hasFood = true; 
            }
            canEat = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            canEat = false;
        }
    }

    void Eat()
    {
        if(playerData.currentHealth < 100)
        {
            playerData.currentHealth = (playerData.currentHealth + foodValue > 100) ? 100 : playerData.currentHealth + foodValue;
        }
 
    }
}
