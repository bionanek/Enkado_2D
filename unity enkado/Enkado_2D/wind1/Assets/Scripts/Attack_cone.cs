using UnityEngine;
using System.Collections;

public class Attack_cone : MonoBehaviour
{

    public Turret turret;
    public bool isLeft = false;


    void Awake()
    {
        turret = GetComponentInParent<Turret>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            if (isLeft)
            {
                turret.Attack(false);
            }
            else
            {
                turret.Attack(true);
            }
        }
        
    }
}
