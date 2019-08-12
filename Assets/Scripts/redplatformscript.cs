using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redplatformscript : MonoBehaviour
{
    public float maxleft;
    public float maxright;
    int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if (pos.x < maxleft)
        { direction = 0; }
        if (pos.x > maxright)
        { direction = 1; }
        if (direction == 0)
        {
            //Debug.Log("PurpleOui");
            transform.Translate(Vector2.right *2* Time.deltaTime);
        }
        if (direction == 1)
        {
            //Debug.Log("PurpleOui");
            transform.Translate(-Vector2.right *2* Time.deltaTime);
        }
    }
}
