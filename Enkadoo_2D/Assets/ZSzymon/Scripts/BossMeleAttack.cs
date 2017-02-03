using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleAttack : MonoBehaviour
{
    public GameObject Parent;
    public GameObject anim;
    public GameObject MainCol;
    public GameObject Target;
    private BossMainScript mainScript;
    private Vector2 walkDir;
    public float TimeToSetUlt = 10f;
    private float TimeToUlt;


    void Start()
    {
        mainScript = MainCol.GetComponent<BossMainScript>(); //pobrnaie skyhrptu 
        TimeToUlt = TimeToSetUlt; //ustawianie czasu do ulta
        walkDir = Vector2.right * 80f; //predkosc 
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("player"))
        {
            anim.GetComponent<Animator>().SetBool("EnemyIsInRange", false);  //przekazanie arguemntu do animacji
            anim.GetComponent<Animator>().SetBool("MeleAtack", true);  //przekazanie arguemntu do animacji
            mainScript.walkDir = Vector2.zero; //zatrzymanie bosa
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("player"))
        {
            TimeToUlt -= Time.deltaTime;

            if (TimeToUlt < 0)
            {
                anim.GetComponent<Animator>().SetBool("MeleAtack", false);  //przekazanie arguemntu do animacji
                anim.GetComponent<Animator>().SetBool("SpecialAttack", true);  //przekazanie arguemntu do animacji
                TimeToUlt = TimeToSetUlt; //ustawienei od nowa czasu do ulta
            }
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {

        if (coll.CompareTag("player"))
        {
            anim.GetComponent<Animator>().SetBool("SpecialAttack", false);  //przekazanie arguemntu do animacji
            anim.GetComponent<Animator>().SetBool("EnemyIsInRange", true);  //przekazanie arguemntu do animacji
            anim.GetComponent<Animator>().SetBool("MeleAtack", false);  //przekazanie arguemntu do animacji
            if (Parent.transform.localScale.x > 0)
            {
                mainScript.walkDir = walkDir; //ustwienei kierunek bosa
            }
            else
            {
                mainScript.walkDir = walkDir*-1; // ustwienei keirunku bosa
            }
        }
    }
}
