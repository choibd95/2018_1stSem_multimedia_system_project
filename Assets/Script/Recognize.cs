using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recognize : MonoBehaviour
{
    public GameObject hand;
    public ParticleSystem water;
    [HideInInspector]
    public ObjectGlow[] oulineRender;

    [HideInInspector]
    public bool is_fireEx;

    private Vector3 ScreenCenter;
    ObjectGlow objGlow;


    public bool isGet;

    PlayerCondition condition; 

    RaycastHit hit;
    [HideInInspector]
    public int hold_handkerchief;
    [HideInInspector]
    // 제리캔 bool / 잡고 있는지 잡고 있지 않은지
    public bool hold_jerrycan;
    [HideInInspector]
    // 제리캔 water / 제리캔에 물을 넣었는지 안넣었는지, 한번 설정하면 불변
    public bool jerrycan_watered;
    [HideInInspector]
    public bool is_Towel;
    [HideInInspector]
    public bool soakedTowel;

    SmallFireTouch small_fire;

    UIoutput ui;
    AudioSource waterSound;
    public AudioSource pickupsound;

    // Use this for initialization
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        condition = GameObject.FindWithTag("Player").GetComponent<PlayerCondition>();
        water.enableEmission = false;
        hand = GameObject.Find("Hand");
        waterSound = water.GetComponent<AudioSource>();
        hold_handkerchief = 0;
        small_fire = GameObject.Find("Fireball_big_red_Door").GetComponent<SmallFireTouch>();
        ui = GameObject.Find("Canvas").GetComponent<UIoutput>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(water.enableEmission);
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);

        if (Physics.Raycast(ray, out hit, 50.0f))
        {
            if (hit.collider.gameObject.tag == "PickUp")
            {
                objGlow = hit.collider.GetComponent<ObjectGlow>();
                objGlow.Selected();

                BoxCollider boxcol = hit.collider.GetComponent<BoxCollider>();
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

                if (OVRInput.Get(OVRInput.Button.One) && isGet==false)
                {
                    isGet = true;
                    boxcol.enabled = false;
                    Destroy(rb);

                    hit.transform.position = hand.transform.position;
                    hit.transform.parent = hand.transform;

                    if (hit.collider.gameObject.name == "Jerrycan")
                        hold_jerrycan = true;
                    else if (hit.collider.gameObject.name == "fire extinguisher")
                    {
                        is_fireEx = true;
                    }
                }
            }else if(objGlow!=null){
                objGlow.NotSelected();
            }

            if (hit.collider.gameObject.tag == "handkerchief")
            {
                objGlow = hit.collider.GetComponent<ObjectGlow>();
                objGlow.Selected();
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    pickupsound.Play();
                    hit.collider.gameObject.SetActive(false);
                    hold_handkerchief++;
                }
            }
            if (hit.collider.gameObject.name == "towel1")
            {
                objGlow = hit.collider.GetComponent<ObjectGlow>();
                objGlow.Selected();
                is_Towel = true;
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    pickupsound.Play();
                    hit.collider.gameObject.SetActive(false);
                }
            }

            if (OVRInput.Get(OVRInput.Button.One) && hit.collider.gameObject.tag == "sinkhandle")
            {
                if (water.enableEmission == false)
                {
                    waterSound.Play();
                    water.enableEmission = true;
                }

                if (hold_jerrycan && !jerrycan_watered)
                {
                    jerrycan_watered = true;
                    ui.announcing = true;
                    ui.announcing_about = 2;
                }
                // 손수건을 들고 있는 상태(1)에서 2가 되면 더 이상 손수건 변수는 바뀌지 않음
                if (hold_handkerchief == 1)
                {
                    hold_handkerchief++;
                    ui.announcing = true;
                    ui.announcing_about = 1;
                }
                if(is_Towel && !soakedTowel) {
                    soakedTowel = true;
                    ui.announcing = true;
                    ui.announcing_about = 3;
                }
            }
        }
    }
}
