using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ectoplasmscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bluescream" || collision.gameObject.tag == "yellowscream")
        {
            
            gameObject.SetActive(false);
            GameState.shieldHealth += 10;

        }
    }
}
