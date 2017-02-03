using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimAttack : MonoBehaviour {

    public GameObject Target;

    public void Attack()
    {
        Target.GetComponent<player>().Damage(1); //smok zadaje obrzenia tym
    }
}
