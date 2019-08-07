using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float PatrolSpeed;
    public float platformRayDistance;
    public float playerRayDistance;

    public bool movingLeft = true;
    private bool playerDetected = false;
    //private bool playerIsInRange;

    public Transform groundDetector;
    public Transform playerDetector;
    public Transform bombSpawner;

    bool attacked = false;
    public GameObject Bomb;
    public int BombSpeed;

    private int PlayerLayer = 1 << 8;

    private void Start()
    {
          
    }

    IEnumerator StartPatrol()
    {
        

        RaycastHit2D groundDetection = Physics2D.Raycast(groundDetector.position, Vector2.down, platformRayDistance);

        transform.Translate(Vector2.left * PatrolSpeed * Time.deltaTime);
            if (groundDetection.collider == false)
            {
                if (movingLeft == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingLeft = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingLeft = true;
                }
            }
        
        yield return new WaitForEndOfFrame();

    }

    IEnumerator attackPlayer()
    {
        GameObject Bombinstance = Instantiate(Bomb, bombSpawner.transform.position,Quaternion.identity);
        /*Bombinstance.GetComponent<Rigidbody2D>().AddForce(playerDetector.forward * BombSpeed, ForceMode2D.Force);
       */ attacked = true;
        yield return new WaitForSeconds(1f);
        attacked = false;
    }


    private void playerdetection()
    {
        /*if(playerIsInRange)
        {
            Vector2 targetDir = GameObject.Find("Player").GetComponent<Transform>().position - transform.position;
            float fieldOfVision = Vector2.Angle(targetDir, transform.forward);

            if(fieldOfVision < 65)
            { */
                RaycastHit2D playerDetection = Physics2D.Raycast(playerDetector.position, Vector2.down, playerRayDistance/*, PlayerLayer*/);

                if (playerDetection.collider.tag == "Player")
                {
                    playerDetected = true;
                }
                else
                {
                    playerDetected = false;
                }
            //}
        //}

    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIsInRange = true;
        }
        else
        {
            playerIsInRange = false;
        }
    }*/
    private void FixedUpdate()
    {
        playerdetection();
        if(playerDetected == false)
        { 
            StartCoroutine(StartPatrol());
        }
        else
        {
            if (!attacked)
            {
                StartCoroutine(attackPlayer());
                Debug.Log("Attacking Now");
            }
        }

    }


}
