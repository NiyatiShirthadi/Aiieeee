using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool enter;
    void Start()
    {
        enter = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            if (enter)
            {
                enter = false;
                EnemyScript.doMelee();
            }
            else {
                enter = true;
            }
            
        }
    }

  
}
