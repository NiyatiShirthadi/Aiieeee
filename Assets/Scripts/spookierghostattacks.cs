using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spookierghostattacks : MonoBehaviour
{
    public GameObject bluewave;
    public GameObject yellowwave;
    float timer1;
    float timer2;
    public int bulcount;
    public Transform spawn;
    private float flip;
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
        if (timer1 >= 0.5f && bulcount < 4)
        {
            Debug.Log(flip);
            flip = Random.Range(0, 2);
            if (flip >= 0.5f)
            {
                Debug.Log("spookyattack");
                var wave = (GameObject)Instantiate(bluewave, spawn.position, spawn.rotation);
               // wave.GetComponent<Rigidbody2D>().velocity = Vector2.right * -10;
                timer1 = 0;
                bulcount++;
            }
            else if (flip <= 0.5f)
            {
                var wave2 = (GameObject)Instantiate(yellowwave, spawn.position, spawn.rotation);
                //ylwbullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -10;
                timer1 = 0;
                bulcount++;
            }
        }
        if (bulcount == 4)
        {
            timer2 += Time.fixedDeltaTime;
            if (timer2 >= 2f)
            {
                bulcount = 0;
                timer2 = 0;
            }
        }
    }
}
