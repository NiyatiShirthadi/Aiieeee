using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spookyghostbehavior : MonoBehaviour
{
    public bool hasdetected;
    public Transform playerpos;
    public float speed;
    Rigidbody2D rb;
    private Vector2 movement;
    private float timer1;
    public Transform spawn;
    public GameObject self;
    public GameObject self1;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        //spawn.position = new Vector2(2.52f,4.56f);

        hasdetected = false;
        rb = GetComponent<Rigidbody2D>();
        timer1 = 0;
        

        sr = GetComponent<SpriteRenderer>();
        rb.isKinematic = true;
        sr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn = GameObject.Transform;
        //playerpos = GameObject.Find("Player").transform;
        if (hasdetected == true)
        {
         //   Debug.Log("detection");
            Vector3 direction = playerpos.position - transform.position;
            direction.Normalize();
            movement = direction;
            moveCharacter(movement);
            
           

            
        }

    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * 2f * Time.deltaTime));

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yellowscream")
        {
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "bluescream")
        {
            //Destroy(gameObject);
            rb.isKinematic = false;
            sr.enabled = false;
            StartCoroutine (respawner());
            


        }
        if (collision.gameObject.tag == "yellowscream")
        {
            //Destroy(gameObject);
            rb.isKinematic = false;
            sr.enabled = false;
            StartCoroutine(respawner());



        }
        if (collision.gameObject.tag == "Player")
        {
            GameState.doDamage(10f);
        }
    }
    public IEnumerator respawner()
    {
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        
        rb.isKinematic = true;
        transform.Translate(0,3,0);
        sr.enabled = true;
        //var res = Instantiate(self,spawn.position, spawn.rotation);
        //Destroy(gameObject);
        //gameObject.transform.position = spawn.position;
        //gameObject.SetActive(true);
        //yield return null;
    }
}
