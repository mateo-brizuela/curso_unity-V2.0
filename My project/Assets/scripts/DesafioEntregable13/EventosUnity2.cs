using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventosUnity2 : MonoBehaviour
{
    public GameObject player;
    public GameObject TPLocation;
    [SerializeField] public UnityEvent teletransportacion;

    public void TP()
    {
        player.transform.position = TPLocation.transform.position;
    }

    void OnTriggerEnter(Collider col) 
    {
        teletransportacion?.Invoke();    
    }

}
