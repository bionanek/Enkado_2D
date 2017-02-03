using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimAttack : MonoBehaviour
{
    public GameObject Target;

    public void Attack()
    {
        Target.GetComponent<player>().Damage(1); //zadnaie obraz playerowi
    }
    public void Ult() //metoda wywlywana w animacji
    {
        Target.GetComponent<par>().post(5f,0f); //wywoalnei metody post z skyrptu par
        Target.GetComponent<player>().Damage(5); //zadnaie orbzen playeorwi
        GetComponent<Animator>().SetBool("MeleAtack", true); //przekazanie arguemntu do animacji
        GetComponent<Animator>().SetBool("SpecialAttack", false);  //przekazanie arguemntu do animacji
    }
}
