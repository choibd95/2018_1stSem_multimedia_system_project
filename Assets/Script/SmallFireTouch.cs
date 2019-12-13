using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallFireTouch : MonoBehaviour {

    UIoutput ui;
    GameObject player;
    Recognize recognize;

	// Use this for initialization
	void Start () {
        ui = GameObject.Find("Canvas").GetComponent<UIoutput>();
        player = GameObject.FindWithTag("Player");
        recognize = player.GetComponent<Recognize>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter (Collider collider) {

        if (collider.gameObject.name == "Player") {
            ui.warning = true;
            if (!recognize.hold_jerrycan || !recognize.jerrycan_watered)
                ui.warning_about = 2;
            else if (recognize.hold_jerrycan && recognize.jerrycan_watered)
                ui.warning_about = 4;
        }
        
    }
}
