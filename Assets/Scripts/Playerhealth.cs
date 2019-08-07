using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    public static int chealth;
    public static int cshields;

    // Start is called before the first frame update
    void Start()
    {

        chealth = 100;
        cshields = 0;
    }

    // Update is called once per frame
    void Update()
    {
        chealth -= 1;
        cshields += 1;
        if (chealth <= 0)
        { chealth = 0; }
        if (chealth >= 100)
        {
            chealth = 100;
        }
        if (cshields <= 0)
        {
            cshields = 0;
        }
        if (cshields >= 100)
        {
            cshields = 100;
        }
    }
}

