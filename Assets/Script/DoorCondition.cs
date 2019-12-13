using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCondition : MonoBehaviour
{

    UIoutput ui;
    Recognize rec;
    DoorRotation doorRotation;
    AudioSource openSound;
    bool playOnce;

    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIoutput>();
        rec = GameObject.FindWithTag("Player").GetComponent<Recognize>();
        doorRotation = GetComponent<DoorRotation>();
        openSound = GetComponent<AudioSource>();
        playOnce = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            if (rec.hold_handkerchief == 2)
            {
                if (playOnce)
                    return;
                openSound.Play();
                playOnce = true;
                doorRotation.isOpen = true;
            }
            else
            {
                ui.warning = true;
                ui.warning_about = 1;
            }
            if (playOnce)
                return;

        }
    }
}
