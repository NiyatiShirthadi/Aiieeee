using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostdetection : MonoBehaviour
{
   

    // GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        // parent = GameObject.Find("spookyghost");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("detect1");
            transform.parent.GetComponent<spookyghostbehavior>().hasdetected = true;

        }
        
    }
    
}
