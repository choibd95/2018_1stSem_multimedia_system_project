using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachChild : MonoBehaviour {
    Rigidbody rb;
    BoxCollider boxCollider;
    GameObject player;
    Recognize recognize;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        recognize = player.GetComponent<Recognize>();
        //rb = gameObject.GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.Get(OVRInput.Button.Two) && recognize.isGet && this.transform.parent !=null)
        {
            this.transform.parent.DetachChildren();
            rb = this.gameObject.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            boxCollider.enabled = true;
            recognize.isGet = false;
            recognize.hold_jerrycan = false;
            recognize.is_fireEx = false;
        }
	}
}
