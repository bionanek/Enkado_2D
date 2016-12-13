using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCloud : MonoBehaviour
{

    public float timeToDestroy = 1f;
    private float timer;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlayerFeet")
        {
            timer = 0;
        }
    }

    void Start()
    {
        timer = 20f;
    }

    void Update()
    {
        if (timer < timeToDestroy)
        {
            timeToDestroy -= Time.deltaTime;
        }
        if (timeToDestroy < 0)
        {
            Destroy(gameObject);
        }
    }
}
