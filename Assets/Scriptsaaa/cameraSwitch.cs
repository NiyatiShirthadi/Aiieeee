using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public bool cameraOneActive;
    public bool cameraTwoActive;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;

    void Start()
    {
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();

        cameraOneActive = true;
        cameraTwoActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
           
                Debug.Log("collision");
                cameraTwo.SetActive(true);
                cameraTwoAudioLis.enabled = true;

                cameraOneAudioLis.enabled = false;
                cameraOne.SetActive(false);

                cameraTwoActive = true;
                cameraOneActive = false;
           
           
        }
        

     
    }
}
