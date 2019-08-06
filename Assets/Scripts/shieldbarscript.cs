using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldbarscript : MonoBehaviour
{
    public Slider shieldbar;
    public static int currentshield;
    public int maxshields;
    // Start is called before the first frame update
    void Start()
    {
       // currentshield = 0;

    }

    // Update is called once per frame
    void Update()
    {
        currentshield = Playerhealth.cshields;
        shieldbar.maxValue = maxshields;
        shieldbar.value = currentshield;
        
    }
}
