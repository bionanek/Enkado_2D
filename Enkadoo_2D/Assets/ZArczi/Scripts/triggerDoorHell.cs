using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoorHell : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            GetComponent<Animator>().SetBool("IsOpened", true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
           GetComponent<Animator>().SetBool("IsOpened",false);
        }
    }
}
