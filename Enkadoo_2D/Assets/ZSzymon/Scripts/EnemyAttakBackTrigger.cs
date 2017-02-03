using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttakBackTrigger : MonoBehaviour
{

    public GameObject MainSkieletionCollider;
    private EnemySkielScript skielScript;

    void Start()
    {
        skielScript = MainSkieletionCollider.GetComponent<EnemySkielScript>(); //pobrnaie skyrptu
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("player"))
        {
            skielScript.ChangeDirection(); //zmiana kierunku 
        }
    } 
}
