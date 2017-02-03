using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour {

    public int damage = 10;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("WindSpell"))
        {
            Destroy(transform.parent.gameObject);
        }
        if (!col.isTrigger && col.CompareTag("player"))
        {
            col.SendMessageUpwards("Damage", damage);
        }
    }
}
