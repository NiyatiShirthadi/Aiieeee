using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    private bool isMovingLeft;
    private void Start()
    {
        GameObject LuggageEnemy = GameObject.Find("LuggageThrower Variant");
        isMovingLeft = LuggageEnemy.GetComponent<patrol>().movingLeft;
        if(isMovingLeft == true)
        {
            Debug.Log("attack");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10f,-30f), Random.Range(10f, 40f)));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(10f, 30f), Random.Range(10f, 40f)));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Player")
        {
            Debug.Log("Juju is a stupid");
            Destroy(gameObject);
        }
    }
    
}
