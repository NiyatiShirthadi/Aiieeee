using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluescreamscript : MonoBehaviour
{
    //public SpriteRenderer sprRend;
    // Start is called before the first frame update
    private float timer;
    public float timetolive;
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3( 1f, 1f,0);
        timer += Time.deltaTime;
        if (timer >= timetolive)
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyblue")
        {
            Debug.Log("Hitttt!!!!!!!!!!!!");
            GameState.shieldHealth += 10;
            Destroy(collision.gameObject);

        }

       
    }

}
