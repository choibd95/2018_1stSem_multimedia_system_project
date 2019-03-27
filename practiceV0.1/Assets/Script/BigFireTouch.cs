using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigFireTouch : MonoBehaviour {

    UIoutput ui;
    GameObject player;
    Recognize recognize;

    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIoutput>();
        player = GameObject.FindWithTag("Player");
        recognize = player.GetComponent<Recognize>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        
        ui.warning_about = 3;
        if (recognize.soakedTowel) {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.enabled = false;
        }
        else {
            ui.warning = true;
            if (!recognize.is_Towel)
                ui.warning_about = 3;
            else
                ui.warning_about = 5;
        }
    }
}
