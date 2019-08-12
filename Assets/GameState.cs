using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static float playerHealth = 100f;
    public float maxHealth;
    public static float shieldHealth = 100f;
    public Transform teleportTo;
    public static GameObject player;
    static bool damageDone;
   public  static bool hasYPower=false;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100f;
        playerHealth = 100f;
        player = GameObject.Find("player");
    }


    public static void doDamage(float damage) {

        if (shieldHealth > 0)
        {
            shieldHealth -= damage;
        }
        else {
            playerHealth -= damage;
           
        }

        damageDone = true;

      

    }

    

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0f)
        { playerHealth = 0f; }
        if (playerHealth >= 100f)
        {
            playerHealth = 100f;
        }
        if (shieldHealth <= 0f)
        {
            shieldHealth = 0f;
        }
        if (shieldHealth >= 100f)
        {
            shieldHealth = 100f;
        }

        if (playerHealth == 0)
        {
            playermovement move = FindObjectOfType<playermovement>();
            EnemyScript.doRoam();
            move.Death();

           
        }

        if (damageDone) {

            player.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(whitecolor());
        }
    }

    static IEnumerator whitecolor()
    {
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<SpriteRenderer>().color = Color.white;
        damageDone = false;
    }


}
