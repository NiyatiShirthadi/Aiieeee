using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : StateMachineBehaviour
{
    private float timeBtwShots;
    public float startTimeBtShots;

    public float stoppingDistance;
    public float retreatDistance;
    public float speed;
    public Transform player;

    public GameObject projectile;

    public GameObject bluebullet;
    public GameObject bluebullet1;
    public GameObject ylwbullet;
    public GameObject ylwbullet1;
    public float timer1;
    public float timer2;
    public int bulcount;
    public Transform spawn;
    private float flip;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeBtwShots = startTimeBtShots;
       // projectile = animator.gameObject.GetComponent<EnemyScript>().projectile;
        bluebullet1 = animator.gameObject.GetComponent<EnemyScript>().projectile1;
        ylwbullet1 = animator.gameObject.GetComponent<EnemyScript>().projectile2;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timeBtwShots <= 0)
        {
            //Instantiate(projectile, animator.transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtShots;
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }

        Roam(animator);



        timer1 += Time.fixedDeltaTime;
        if (timer1 >= 2f && bulcount < 2)
        {
            Debug.Log(flip);
            flip = Random.Range(0, 2);
            if (flip >= 0.5f)
            {
                GameObject bluebullet = (GameObject)Instantiate(bluebullet1, animator.transform.position, Quaternion.identity);
                //bluebullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -10;
                timer1 = 0;
                bulcount++;
            }
            else if (flip <= 0.5f)
            {
                GameObject ylwbullet = (GameObject)Instantiate(ylwbullet1, animator.transform.position, Quaternion.identity);
                //ylwbullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -10;
                timer1 = 0;
                bulcount++;
            }
        }
        if (bulcount == 2)
        {
            timer2 += Time.fixedDeltaTime;
            if (timer2 >= 0.5f)
            {
                bulcount = 0;
                timer2 = 0;
            }
        }


    }

    void Roam(Animator animator) {
        if (Vector2.Distance(animator.transform.position, player.position) > stoppingDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(animator.transform.position, player.position) < stoppingDistance && Vector2.Distance(animator.transform.position, player.position) > retreatDistance)
        {
            animator.transform.position = animator.transform.position;
        }
        else if (Vector2.Distance(animator.transform.position, player.position) < retreatDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, -speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
