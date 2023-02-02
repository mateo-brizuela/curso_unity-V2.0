using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScipts : MonoBehaviour
{
    public Personaje5 punt;
    public GameObject cargador00;
    public GameObject cargador01;
    public GameObject cargador02;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginWalk()
    {
        punt.cShoot = true;
    }

    public void BeginIdle()
    {
        punt.cShoot = true;
    }

    public void BeginReload()
    {
        punt.cShoot = false;
    }

    public void EndReload()
    {
        punt.cShoot = true;
    }
    
    public void cargador1()
    {
        cargador01.SetActive(true);
        cargador00.SetActive(false);
    }

    public void cargador2()
    {
        cargador01.SetActive(false);
        cargador02.SetActive(true);
    }

    public void cargador0()
    {
        cargador02.SetActive(false);
        cargador00.SetActive(true);
    }
}
