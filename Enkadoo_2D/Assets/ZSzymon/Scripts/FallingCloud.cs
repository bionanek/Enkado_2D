using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCloud : MonoBehaviour
{

    public float timeToDestroy = 3f;
    private float timer;

    void OnTriggerEnter2D(Collider2D coll) //gdy dotknei nog gracza odpala sie timer ktory powoduej ze platforma spada
    {
        if (coll.gameObject.tag == "PlayerFeet")
        {
            timer = 0;
        }
    }

    void Start()
    {
        timer = 20f; //dlugosc na start 20
    }

    void Update()
    {
        if (timer < timeToDestroy)
        {
            timeToDestroy -= Time.deltaTime;
        }
        if (timeToDestroy < 0)
        {
            if (gameObject.GetComponent<Rigidbody2D>() == null) //sprawdzneie czy napewno platforma nie ma rigibody
                gameObject.AddComponent<Rigidbody2D>(); //nadanie ciala -> platforma zaczyna spadac
        }
        if (gameObject.transform.position.y < -5f)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (gameObject.transform.position.y < -20f)
        {
            Destroy(gameObject);
        }
    }
}
