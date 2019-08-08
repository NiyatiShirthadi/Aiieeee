using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum attackstate
{
attacking,
idle
}

public class screamattacks : MonoBehaviour
{
    public attackstate current;
    public GameObject bluescream;
    public GameObject bluescream1;
    public GameObject yellowscream;
    public GameObject yellowscream1;
    public Transform spawn;

    float timer1;
    // Start is called before the first frame update
    void Start()
    {
        timer1 = 0.0f;
        current = attackstate.idle;
    }

    // Update is called once per frame
    void Update()
    {
        GetAttack();
        //Debug.Log("Attackstate is " + current);
        
       
    }

    void GetAttack()
    {
        if (Input.GetButton("Fire1")&& current==attackstate.idle)
        
        {
            StartCoroutine(attackblu());
        }
        if (Input.GetButton("Fire2") && current == attackstate.idle)

        {
            StartCoroutine(attackylw());
        }
    }
    private IEnumerator attackblu()
    {
        current = attackstate.attacking;
        GameObject bluescream = (GameObject)Instantiate(bluescream1, spawn.position, spawn.rotation);
        //current = attackstate.attacking;
        yield return new WaitForSeconds(0.25f);
        current = attackstate.idle;

    }
    private IEnumerator attackylw()
    {
        current = attackstate.attacking;
        GameObject yellowcream = (GameObject)Instantiate(yellowscream1, spawn.position, spawn.rotation);
        //current = attackstate.attacking;
        yield return new WaitForSeconds(0.25f);
        current = attackstate.idle;

    }

}
