using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie2AnimationScript : MonoBehaviour
{
    public Personaje5 punt;
    public void attackPlayer()
    {
        punt.attacked = true;
    }
}
