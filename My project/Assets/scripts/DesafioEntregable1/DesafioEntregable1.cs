using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioEntregable1 : MonoBehaviour
{
    [SerializeField]
    Vector3 playerSpeed;
    [SerializeField]
    Vector3 playerScale;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(playerSpeed*Time.deltaTime);
        transform.localScale = (playerScale);
    }
}
