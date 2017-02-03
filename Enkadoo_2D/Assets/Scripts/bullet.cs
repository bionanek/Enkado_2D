using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            if (col.CompareTag("player"))
            {

                col.GetComponent<player>().Damage(1); //zadaje playerowi obrzenie
            }
            Destroy(gameObject);
        }
    }
}
