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
    Animator m_Animator;
    public GameObject projectile;

    public Transform player;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetTrigger("isPatrol");
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("platform").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        m_Animator.SetTrigger("isShooting");
       // m_Animator.SetTrigger("isMelee");
        m_Animator.ResetTrigger("isPatrol");
    }

    // Update is called once per frame
    void Update()
    {
       // if (Vector2.Distance(transform.position, player.position) > stoppingDistance) {
         //   transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //} else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
         //   transform.position = this.transform.position;
        //} else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
          //  transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}
    }
}
