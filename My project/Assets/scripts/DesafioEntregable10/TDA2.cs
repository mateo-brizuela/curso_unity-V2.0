using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDA2 : MonoBehaviour
{
    int Tp = 0;
    public List <GameObject> SpawnPos = new List <GameObject>();

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            int limit = SpawnPos.Count;
            GameObject TpPos;
            TpPos = SpawnPos[Tp];
            transform.position = TpPos.transform.position;

            if(Tp < limit-1)
            {
                Tp++;
            }else
            {
                Tp = 0;
            }
        }    
    }
}
