using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (!col.isTrigger && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage",damage); //wyslanei wiaodmosci o tym ze ma dostac obrazenia
        }
    }
}
