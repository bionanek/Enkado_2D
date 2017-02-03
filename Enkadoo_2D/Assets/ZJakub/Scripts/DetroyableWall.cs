using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyableWall : MonoBehaviour
{

    public int hp = 100;
	// Use this for initialization

    public void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }        
    }

}
