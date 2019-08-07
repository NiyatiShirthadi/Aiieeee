using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    public static float chealth;
    public static float cshields;

    // Start is called before the first frame update
    void Start()
    {

        chealth = GameState.playerHealth;
        cshields = GameState.shieldHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //chealth -= 1;
        //cshields += 1;
        if (chealth <= 0f)
        { chealth = 0f; }
        if (chealth >= 100f)
        {
            chealth = 100f;
        }
        if (cshields <= 0f)
        {
            cshields = 0f;
        }
        if (cshields >= 100f)
        {
            cshields = 100f;
        }
    }
}

