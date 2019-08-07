using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldbarscript : MonoBehaviour
{
    public Slider shieldbar;
    public static float currentshield;
    public float maxshields;
    // Start is called before the first frame update
    void Start()
    {
       // currentshield = 0;

    }

    // Update is called once per frame
    void Update()
    {

        currentshield = GameState.shieldHealth;
        shieldbar.maxValue = maxshields;
        shieldbar.value = currentshield;
        
    }
}
