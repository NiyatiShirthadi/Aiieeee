using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    walk,
    jump,
    hitstun
}

public class playermovement : MonoBehaviour
{
    public float speed;
    public PlayerState currentState;
    public float jforce;
    public Rigidbody2D rb;
   // private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetInput();
        checkwalkstate();
       
        Debug.Log(currentState);
        
    }
    void GetInput()
    {
       // change = Vector2.zero;
       // change.y = Input.GetAxis("Horizontal");

    }
    void checkwalkstate()
    {
        if (currentState != PlayerState.hitstun)
        {
            float move = Input.GetAxis("Horizontal")*speed;
            transform.Translate(move,0,0);
        }
        if (currentState != PlayerState.jump)
        {
            if (Input.GetButton("Jump"))
            {
                
                rb.AddForce(transform.up * jforce);
                currentState = PlayerState.jump;
            }
        }

    }
   
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "platformtop")
            {
                currentState = PlayerState.walk;
            }
        }
    
}
