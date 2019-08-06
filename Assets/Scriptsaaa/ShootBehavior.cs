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

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeBtwShots = startTimeBtShots;
        projectile = animator.gameObject.GetComponent<EnemyScript>().projectile;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, animator.transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtShots;
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }

        Roam(animator);
       
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
