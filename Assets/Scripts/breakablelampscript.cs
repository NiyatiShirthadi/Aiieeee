using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakablelampscript : MonoBehaviour
{
    public GameObject lampspawn;
    //public Transform self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bluescream" || collision.gameObject.tag =="yellowscream" )
        {
            //var drop = Instantiate(lampspawn, transform.position, transform.rotation);
            Invoke("spawner", 1f);
            gameObject.SetActive(false);

        }
    }
    void spawner()
    {
        var drop = Instantiate(lampspawn, transform.position, transform.rotation);
    }
}
