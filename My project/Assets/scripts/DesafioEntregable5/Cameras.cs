using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    void Update()
    {
        SwitchCameras();
    }

    void SwitchCameras()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(cam1.activeInHierarchy)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }else
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
        }
    }
}
