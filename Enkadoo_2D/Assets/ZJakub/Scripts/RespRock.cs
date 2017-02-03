using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespRock : MonoBehaviour
{

    public bool isRolling = true;
    private Rigidbody2D rgb2;
    public GameObject Player;

    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        rgb2.AddForce(Vector2.right*1.5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("StopTheRock"))
        {
            gameObject.GetComponent<ConstantForce2D>().enabled = false;
            gameObject.GetComponent<Animator>().Stop();
            isRolling = false;
        }
        if (col.CompareTag("player") && isRolling)
        {
            Player.GetComponent<player>().curHealth = 0;
        }
    }


}
