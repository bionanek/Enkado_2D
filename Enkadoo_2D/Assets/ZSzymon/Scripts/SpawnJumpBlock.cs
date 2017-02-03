using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJumpBlock : MonoBehaviour
{
    public GameObject jumpBlock;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("FireBall"))
        {
            Instantiate(jumpBlock, transform.position, transform.rotation); //spawn klocka po trafnie fireballem z wodospadu
            Destroy(gameObject);
        }
    }

}
