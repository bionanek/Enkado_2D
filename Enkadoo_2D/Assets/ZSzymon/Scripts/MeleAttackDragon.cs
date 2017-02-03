using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAttackDragon : MonoBehaviour {

    public GameObject Parent;
    public GameObject anim;
    public GameObject MainCol;
    public GameObject Target;
    private MainColliderEnemyDragon mainScript;
    private Vector2 walkDir;


    void Start()
    {
        mainScript = MainCol.GetComponent<MainColliderEnemyDragon>(); //pobrnaie skryptu 
        walkDir = Vector2.right * 180f; //usawnie predkosci
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("player"))
        {
            anim.GetComponent<Animator>().SetBool("MeleAttack", true);  //przekazanie arguemntu do animacji
            mainScript.walkDir = Vector2.zero; //ustawienie predkosci na 0
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {

        if (coll.CompareTag("player"))
        {
            anim.GetComponent<Animator>().SetBool("MeleAttack", false);  //przekazanie arguemntu do animacji
            if (Parent.transform.localScale.x > 0)
            {
                mainScript.walkDir = walkDir; //ustawianie keirunki i predkosci
            }
            else
            {
                mainScript.walkDir = walkDir * -1; //ustawienie kierunku i predkosci
            }
        }
    }
}
