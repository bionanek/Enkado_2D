using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private bool onTop;
    public GameObject bouncer;
    public Vector2 velocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("player") & onTop)
        {
            bouncer = col.gameObject;
            Jump();
        }
    }

    void Jump()
    {
        bouncer.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void OnTriggerEnter2D()
    {
        onTop = true;
    }

    void OnTriggerExit2D()
    {
        onTop = false;
    }
}
