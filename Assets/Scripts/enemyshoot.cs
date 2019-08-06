using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
    public GameObject bluebullet;
    public GameObject bluebullet1;
    public GameObject ylwbullet;
    public GameObject ylwbullet1;
    public float timer1;
    public float timer2;
    public int bulcount;
    public Transform spawn;
    private float flip;
    //public int 
    // Start is called before the first frame update
    void Start()
    {
        timer1 = 0.0f;
        timer2 = 0.0f;
        bulcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer1 += Time.fixedDeltaTime;
        if (timer1 >= 0.25f && bulcount<4)
        {
            Debug.Log(flip);
            flip = Random.Range(0, 2);
            if (flip >= 0.5f)
            {
                GameObject bluebullet = (GameObject)Instantiate(bluebullet1, spawn.position, spawn.rotation);
                bluebullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -10;
                timer1 = 0;
                bulcount++;
            }
            else if (flip <= 0.5f)
            {
                GameObject ylwbullet = (GameObject)Instantiate(ylwbullet1, spawn.position, spawn.rotation);
                ylwbullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -10;
                timer1 = 0;
                bulcount++;
            }
        }
        if (bulcount == 4)
        {
            timer2 += Time.fixedDeltaTime;
            if (timer2 >= 1f)
            {
                bulcount = 0;
                timer2 = 0;
            }
        }
        Debug.Log("bulcount:"+bulcount);
    }
}