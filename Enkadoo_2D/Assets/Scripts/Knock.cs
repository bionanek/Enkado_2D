using UnityEngine;
using System.Collections;

public class Knock : MonoBehaviour {

    private player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerFeet"))
        {
            player.Damage(2);
            StartCoroutine(player.KnockBack(0.02f, 350, player.transform.position));
        }
    }
}
