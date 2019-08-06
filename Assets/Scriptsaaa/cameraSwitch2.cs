using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch2 : MonoBehaviour
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

        cameraOneActive = false; 
        cameraTwoActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (cameraOneActive)
        {
            Debug.Log("collision");
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            cameraTwoActive = true;
            cameraOneActive = false;
        }
        else
        {
            Debug.Log("collision2");
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            cameraOneActive = true;
            cameraTwoActive = false;

        }

        if (cameraTwoActive)
        {

        }

    }
}
