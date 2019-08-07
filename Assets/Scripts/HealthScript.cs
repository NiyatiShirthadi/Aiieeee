using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthbar;
    public static float currenthealth;
    public float maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealth = GameState.playerHealth;
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!"+currenthealth);
        healthbar.maxValue = maxhealth;
        healthbar.value = currenthealth;
        
    }
}
