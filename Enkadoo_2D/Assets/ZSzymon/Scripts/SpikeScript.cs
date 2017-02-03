using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerFeet"))
        {
            col.GetComponentInParent<player>().Damage(10); //zadnaie 10 obrazen gracozwi
        }
    }
}
