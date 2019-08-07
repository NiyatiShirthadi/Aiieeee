using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpresetscript : MonoBehaviour
{
    public PlayerState st;
    public int jint;

    // Start is called before the first frame update
    void Start()
    {
        jint = 0;
        //   st = transform.parent.GetComponent<playermovement>().currentState;
        st = PlayerState.jump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            st = PlayerState.walk;
            Debug.Log("st updated");
        }
    }
}
