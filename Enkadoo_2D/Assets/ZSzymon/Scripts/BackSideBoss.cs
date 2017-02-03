using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSideBoss : MonoBehaviour {

    public GameObject MainBossColider;
    public GameObject FrontBossColider;
    private BossMainScript BossMainScript;
    private BossFrontSide BossFrontSideScript;

    void Start()
    {
        BossMainScript = MainBossColider.GetComponent<BossMainScript>(); //pobrnaie skryptow
        BossFrontSideScript = FrontBossColider.GetComponent<BossFrontSide>();
    }

    void OnTriggerEnter2D(Collider2D coll) //jezlei plecy bosa wykryja nas to boss sie odwraca
    {
        if (coll.CompareTag("player"))
        {
            BossMainScript.ChangeDirection();
            BossFrontSideScript.ChangeDirection();
        }
    }
}
