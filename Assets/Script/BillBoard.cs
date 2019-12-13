using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {

    private Transform tr;
    private Transform camTr;


	// Use this for initialization
	void Start (){
        tr = GetComponent<Transform>();
        camTr = Camera.main.GetComponent<Transform>()
;	}
	
	// Update is called once per frame
	void Update () {
        tr.LookAt(camTr.position*-1);
	}
}
