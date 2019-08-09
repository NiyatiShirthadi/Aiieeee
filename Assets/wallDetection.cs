using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDetection : MonoBehaviour
{
    private bool isMovingLeft;
    // Start is called before the first frame update
    void Start()
    {
        isMovingLeft = GameObject.Find("LuggageThrower").GetComponent<patrol>().movingLeft;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            Debug.Log("hittingwall");
            if (isMovingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isMovingLeft = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
