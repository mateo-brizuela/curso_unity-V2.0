using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedDorada : MonoBehaviour
{
    float cooldown = 2f;
    float endcooldown;
    float rndx;
    float rndz;
    float rndy;
    bool collision;
    void OnCollisionEnter(Collision Col) 
    {
        if(Col.transform.gameObject.tag == "Player")
        {
            endcooldown = Time.time +cooldown;
        }
    }

    void OnCollisionStay(Collision col2) 
    {
        if(col2.transform.gameObject.tag == "Player")
        {
            collision = true;
        }    
    }

    void OnCollisionExit(Collision col3)
    {
          if(col3.transform.gameObject.tag == "Player")
        {
            collision = false;
        }    
    }

    void Update() 
    {
        if(collision == true && Time.time > endcooldown)
        {
            rndz = Random.Range(5f,5f);
            rndx = Random.Range(5f,1f);
            rndy = Random.Range(1f,180f);
            transform.position = new Vector3(rndx,0,rndz);
            transform.localEulerAngles = new Vector3(0,rndy,0);
            collision = false;
        }    
    }
}