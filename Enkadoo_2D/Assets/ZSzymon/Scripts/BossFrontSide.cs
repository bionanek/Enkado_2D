using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrontSide : MonoBehaviour
{
    public GameObject Parent;
    public GameObject anim;
    public GameObject MainCol;
    public GameObject DoorToClose1;
    public Vector2 walkDir = Vector2.right * 80f;
    private BossMainScript mainScript;
    private bool opened;


    void Start()
    {
        mainScript = MainCol.GetComponent<BossMainScript>();
        opened = true;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("player"))
        {
            if (opened)
            {
                DoorToClose1.GetComponent<Animator>().SetBool("AreOpen",false);  //przekazanie arguemntu do animacji
                opened = false;
            }
            anim.GetComponent<Animator>().SetBool("EnemyIsInRange", true);  //przekazanie arguemntu do animacji
            mainScript.walkDir = walkDir; //nadanie predkosci bosowi


        }

    }

    void OnTriggerExit2D(Collider2D coll)
    {
        
        if (coll.CompareTag("player"))
        {
            anim.GetComponent<Animator>().SetBool("EnemyIsInRange", false);  //przekazanie arguemntu do animacji
            mainScript.walkDir = Vector2.zero; //zatrzymanie bosa
        }
    }

    public void ChangeDirection()
    {
        walkDir = walkDir * (-1); //zmieniee kieurnku bosa
    }
}
