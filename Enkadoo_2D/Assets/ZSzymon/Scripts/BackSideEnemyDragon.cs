using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSideEnemyDragon : MonoBehaviour {

    public GameObject MainDragonCollider;
    private MainColliderEnemyDragon dragonScript;

    void Start()
    {
        dragonScript = MainDragonCollider.GetComponent<MainColliderEnemyDragon>(); // pobrnaiew skryptu
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("player"))
        {
            dragonScript.ChangeDirection(); //odwrocenie sie gdy wykryje smok nas z tylu
        }
    }
}
