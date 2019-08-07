using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState 
{
    public static float playerHealth = 100f;
    public float maxHealth;
    public static float shieldHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100f;
        playerHealth = 100f;
        
    }


    public static void doDamage(float damage) {

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
        if (playerHealth <= 0f)
        { playerHealth = 0f; }
        if (playerHealth >= 100f)
        {
            playerHealth = 100f;
        }
        if (shieldHealth <= 0f)
        {
            shieldHealth = 0f;
        }
        if (shieldHealth >= 100f)
        {
            shieldHealth = 100f;
        }
    }
}
