using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour {
    public ParticleSystem smoke;
    Recognize recognize;
    GameObject Player;
    AudioSource fireExSound;
    void Start(){
        smoke.enableEmission = false;
        Player = GameObject.FindWithTag("Player");
        recognize = Player.GetComponent<Recognize>();
        fireExSound = GetComponent<AudioSource>();
    }

	void Update () {
        if (recognize.is_fireEx)
        {
            if (OVRInput.Get(OVRInput.Button.One))
            {
                if (smoke.enableEmission == true)
                {
                    fireExSound.Stop();
                    smoke.enableEmission = false;
                    return;
                }
                smoke.enableEmission = true;
                fireExSound.Play();
            }
        }
	}
}
