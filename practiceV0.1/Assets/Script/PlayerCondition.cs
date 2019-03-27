using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{

    public bool get_fireEx;
    public bool get_jerrycan;
    public bool is_jerrycanWatered;
    public bool get_fabric;
    public bool is_fabricWatered;
    public bool get_hammer;
    public bool get_curtain;
    public bool is_curtainWatered;

    // Use this for initialization
    void Start()
    {
        get_fireEx = false;
        get_jerrycan = false;
        is_jerrycanWatered = false;
        get_fabric = false;
        is_fabricWatered = false;
        get_hammer = false;
        get_curtain = false;
        is_curtainWatered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("fire extinguisher") == false)
            get_fireEx = true;

        if (GameObject.Find("jerrycan") == false)
            get_jerrycan = true;

        // if (GameObject.Find("") == false)
            // ~~~ = true;
    }
}
