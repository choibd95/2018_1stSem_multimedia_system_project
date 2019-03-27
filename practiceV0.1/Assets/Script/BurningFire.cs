using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningFire : MonoBehaviour
{
    Recognize recognize;
    GameObject player;
    public ParticleSystem smoke;
    bool is_start;

    float currentTime;
    float endTime = 1.5f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        recognize = player.GetComponent<Recognize>();
        is_start = false;
    }
    private void Update()
    {
        if (is_start)
        {
            currentTime += Time.deltaTime;
            Fire_off();
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            if (recognize.is_fireEx && smoke.enableEmission)
            {
                is_start = true;
            }
        }
    }
    void Fire_off(){
        if (transform.localScale != Vector3.zero)
        {
            if (currentTime < endTime)
            {
                transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                //Debug.Log(transform.localScale);
            }
            else if(currentTime >= endTime){
                Destroy(this.gameObject);
                return;
            }
        }
    }
}
