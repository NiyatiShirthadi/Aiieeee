﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    

    void OnCollisionEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            Debug.Log("spiked!");
            GameState.doDamage(10);
        }
    }
}
