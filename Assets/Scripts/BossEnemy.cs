using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour

{

    public float speed;
    public float stoppingDistance;
    public float retreatDistacne;
    public Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject rightprojectile;
    public GameObject leftprojectile;
    public Transform Rightprojectile;
    public Transform Leftprojectile;



    // Start is called before the first frame update
    void Start()
    {

        timeBtwShots = startTimeBtwShots;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        Rightprojectile = GameObject.FindGameObjectWithTag("Right").transform;

        Leftprojectile = GameObject.FindGameObjectWithTag("Left").transform;


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        else if( Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistacne)
        {
            transform.position = this.transform.position;
        }
        else if( Vector2.Distance( transform.position, player.position) < retreatDistacne)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if(timeBtwShots <= 0)
        {
            Instantiate(rightprojectile,Rightprojectile.position, Quaternion.identity);
            Instantiate(leftprojectile,Leftprojectile.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
 