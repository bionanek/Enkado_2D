using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour
{

    private bool attacking = false;
    private float attackTimmer;
    private float attackCd = 0.3f;

    public Collider2D attackCollider;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackCollider.enabled = false;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !attacking)
        {
            attacking = true;
            attackTimmer = attackCd;
            attackCollider.enabled = true;
        }
        if (attacking)
        {
            if (attackTimmer > 0)
            {
                attackTimmer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackCollider.enabled = false;
            }
        }
        anim.SetBool("Attacking",attacking);
    }
}
