using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EndtoTitle : MonoBehaviour
{

    public GameObject otherGb;
    private Vector3 ScreenCenter;

    RaycastHit hit;
    // 카메라의 중앙 지점을 저장하는 변수



    // Use this for initialization
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        //카메라 중앙 좌표부터 레이를 생성
        //ray가 충돌한 지점의 정보를 저장하는 변수


        if (Physics.Raycast(ray, out hit, 100.0f))
        //ray를 100.0f 거리까지 쏘아서 충돌 상태를 확인한다.
        {
            if (hit.collider.gameObject.tag == "GoTitle")
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    SceneManager.LoadScene("Title");
                }
            }

        }

    }
}
