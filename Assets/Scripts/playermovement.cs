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
    public PlayerState check;
    public float jforce;
    public Rigidbody2D rb;
    bool grounded = false;
    public Transform groundcheck;
    public Animator animator;
   // private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetInput();
       
        Debug.Log(currentState);
        grounded = Physics2D.Linecast(transform.position, groundcheck.position, 1 << LayerMask.NameToLayer("Platform"));
        if (grounded == true)
        { currentState = PlayerState.walk; }
        checkwalkstate();
       
       
        
        
    }
    void GetInput()
    {
       // change = Vector2.zero;
       // change.y = Input.GetAxis("Horizontal");

    }
    void checkwalkstate()
    {
        if (currentState != PlayerState.hitstun && currentState!=PlayerState.jump)
        {
            float move = Input.GetAxis("Horizontal")*speed;
            transform.Translate(move,0,0);
            
            if (move != 0)
            {
                animator.SetTrigger("isWalking");
                animator.ResetTrigger("isIdle");
            }
            else {
                animator.SetTrigger("isIdle");
                animator.ResetTrigger("isWalking");
            }

            if (move > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (move < 0) {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            
        }
        if (currentState != PlayerState.hitstun && currentState == PlayerState.jump)
        {
            float move = Input.GetAxis("Horizontal") * speed/2;
            transform.Translate(move, 0, 0);
            //animator.SetTrigger("isWalking");
            if (move != 0)
            {
                animator.SetTrigger("isWalking");
                animator.ResetTrigger("isIdle");
            }
            else { animator.SetTrigger("isIdle");
                animator.ResetTrigger("isWalking");
            }

        }
        if (currentState != PlayerState.jump && grounded==true)
        {
            if (Input.GetButton("Jump"))
            {
                
                rb.AddForce(transform.up * jforce);
                currentState = PlayerState.jump;
                grounded = false;
                //currentState = GameObject.Find("jumpreset").GetComponent<jumpresetscript>().st;
            }
        }

    }
   
       /* void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "platformtop")
            {
                currentState = PlayerState.walk;
            }
        }*/
    
}
