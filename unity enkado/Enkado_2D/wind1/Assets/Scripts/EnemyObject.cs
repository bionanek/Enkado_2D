using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour {

    public int curentHealth;
    public int maxHealth;

    void Start()
    {
        curentHealth = maxHealth;
    }

    void Update()
    {
        if (curentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        curentHealth -= damage;
        gameObject.GetComponent<Animation>().Play("player_RedFlash");
    }
}
