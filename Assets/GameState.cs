using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState 
{
    public static float playerHealth;
    public float maxHealth;
    public static float shieldHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        playerHealth = maxHealth;
        
    }


    void doDamage(float damage) {

        if (shieldHealth > 0)
        {
            shieldHealth -= damage;
        }
        else {
            playerHealth -= damage;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
