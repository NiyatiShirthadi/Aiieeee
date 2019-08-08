using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform[] moveSpots;
    static Animator animator;
    public GameObject projectile;
    public bool enter;
    public Transform player;

    public static float health;

    void Start()
    {
        health = 100;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        //m_Animator.SetTrigger("isPatrol");
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Platform").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        
        // m_Animator.SetTrigger("isMelee");
        //animator.ResetTrigger("isPatrol");
     
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetTrigger("isShooting");


        // if (Vector2.Distance(transform.position, player.position) > stoppingDistance) {
        //   transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //} else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
        //   transform.position = this.transform.position;
        //} else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
        //  transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}

    }

    public static void doMelee() {
        animator.SetTrigger("isShooting");
    }

    void doShooting()
    {

    }

    void doSpawning()
    {

    }

    public void doDamage(float damage) {

        if (health == 0)
        {
            Destroy(gameObject);
        }
        else {
            health -= damage;
            Debug.Log(health);

        }
    
    } 
}
