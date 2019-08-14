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
    public Transform spawn;
    public bool facingRight;
    [SerializeField] public GameObject teleportTo;
    // private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //teleportTo = GameObject.Find("SavePosition");
       // gameObject.transform.position = teleportTo.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //GetInput();
       
        //Debug.Log(currentState);
        grounded = Physics2D.Linecast(transform.position, groundcheck.position, 1 << LayerMask.NameToLayer("Platform"));
        if (grounded == true)
        { currentState = PlayerState.walk;
            animator.ResetTrigger("isJumping");
        }
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
            float h = Input.GetAxis("Horizontal");
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

            if (h > 0 && !facingRight)
            {
                Flip();
            }
            else if (h < 0 && facingRight)
            {
                Flip();
            }


        }
        if (currentState != PlayerState.hitstun && currentState == PlayerState.jump)
        {
            float move = Input.GetAxis("Horizontal") * speed/2;
            transform.Translate(move, 0, 0);
            //animator.SetTrigger("isWalking");
            if (move != 0)
            {
                //animator.SetTrigger("isWalking");
                //animator.ResetTrigger("isIdle");
            }
            else {// animator.SetTrigger("isIdle");
                //animator.ResetTrigger("isWalking");
            }

        }
        if (currentState != PlayerState.jump && grounded==true)
        {
            if (Input.GetButton("Jump"))
            {
                rb.velocity = new Vector2(0,0) ;
                rb.AddForce(transform.up * jforce, ForceMode2D.Impulse);
                currentState = PlayerState.jump;
                animator.SetTrigger("isJumping");
                animator.ResetTrigger("isWalking");
                animator.ResetTrigger("isIdle");
                grounded = false;
                //currentState = GameObject.Find("jumpreset").GetComponent<jumpresetscript>().st;
            }
        }

    }
    
    public void Death()
    {
        GameState.playerHealth= 100f;
        Debug.Log("!!!!!!!!!!!!" +teleportTo);
       transform.position = teleportTo.transform.position;


    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;

    }

       /* void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "platformtop")
            {
                currentState = PlayerState.walk;
            }
        }*/

}
