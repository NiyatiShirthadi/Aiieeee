﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParolBehavior : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   
    public float speed;

    public float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;

    private int randomSpot;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTime = startWaitTime;
        moveSpots = animator.gameObject.GetComponent<EnemyScript>().moveSpots;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.position = Vector2.MoveTowards(animator.gameObject.transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(animator.gameObject.transform.position, moveSpots[randomSpot].position) < 2f){
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else {
                waitTime -= Time.deltaTime;
            }
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