using UnityEngine;
using System.Collections;

public class Attack_cone : MonoBehaviour
{

    public Turret turret;
    public bool isLeft = false;


    void Awake()
    {
        turret = GetComponentInParent<Turret>(); //pobrnaie skyrptu turret
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player")) //jelei obiekt o tagu player stoi w jego polu to ustawia mu atak 
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
