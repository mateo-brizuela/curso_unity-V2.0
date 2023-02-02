using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventosUnity : MonoBehaviour
{
    [SerializeField] public UnityEvent<int> Uevent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) 
    {
        if(col.transform.CompareTag("Player"))
        {
            //Debug.Log("entro el jugador");
            Uevent?.Invoke(1);
            Debug.Log("apareciendo paredes");
        }    
    }

    
}
