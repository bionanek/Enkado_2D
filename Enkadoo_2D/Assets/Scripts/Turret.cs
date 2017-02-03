using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{

    public int curentHealth;
    public int maxHealth;
    public float distance;
    public float awakeRange = 4f;
    public float shootInterval;
    public float bulletSpeed = 10;
    public float bulletTimer;
    public bool awake = false;
    public bool lookingRigth = true;
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        curentHealth = maxHealth;
    }

    void Update()
    {
        anim.SetBool("Awake",awake); //przekazanie arguemntu do animajci
        anim.SetBool("LookingRight", lookingRigth); //przekazanie arguemntu do animajci
        RangeCheck(); //metoda sprawdzajca odleglosc od playera 
        TargetPostion(); // https://www.youtube.com/watch?v=61e4ctomGyM&list=PLq3pyCh4J1B2va_ftIthSpUaQH0LycRA-&index=18 link tlumaczacy jak dziala turet i caly ten skyrpt
        if (curentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void TargetPostion()
    {
        if (target.transform.position.x > transform.position.x)
        {
            lookingRigth = true;
        }
        if (target.transform.position.x < transform.position.x)
        {
            lookingRigth = false;
        }
    }

    private void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < awakeRange)
        {
            awake = true;
        }

        if(distance>awakeRange)
        {
            awake = false;
        }
    }

    public void Attack(bool attackRight)
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {

            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (!attackRight)
            {
                GameObject bulletClone;
                bulletClone =
                    Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as
                        GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction*bulletSpeed;
                bulletTimer = 0;
            }
            if (attackRight)
            {
                GameObject bulletClone;
                bulletClone =
                    Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as
                        GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction*bulletSpeed;
                bulletTimer = 0;
            }
        }
    }

    public void Damage(int damage)
    {
        curentHealth -= damage;
        gameObject.GetComponent<Animation>().Play("player_RedFlash");
    }
}
