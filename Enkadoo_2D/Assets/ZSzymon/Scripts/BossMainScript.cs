using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMainScript : MonoBehaviour
{
    public GameObject Parent;
    public GameObject anim;
    public GameObject Feet;
    public GameObject FrontCol;
    public GameObject BackCol;
    public GameObject Mele;
    public GameObject DoorToOpen2;
    private Rigidbody2D rgbd2;
    public float maxSpeed = 20f;
    public Vector2 walkDir { get; set; }
    public int curentHealth;
    public int maxHealth = 100;

    public bool CanWalk;

    // Use this for initialization
    void Start ()
    {
        curentHealth = maxHealth;
        rgbd2 = Parent.GetComponent<Rigidbody2D>(); //pobranie z rodzica ciala
        anim.GetComponent<Animator>().SetInteger("CurrHp", maxHealth);  //przekazanie arguemntu do animacji
        walkDir =Vector2.zero; //predkosc 0
        
    }
	
	void Update ()
    {
        if (CanWalk) //czy boss ma chodzic czy nie
        {
            rgbd2.AddForce(walkDir);
        }

        if (rgbd2.velocity.x > maxSpeed) //stala predkosc
        {
            rgbd2.velocity = new Vector2(maxSpeed, rgbd2.velocity.y);
        }

        if (rgbd2.velocity.x < -maxSpeed) //stala predkosc
        {
            rgbd2.velocity = new Vector2(-maxSpeed, rgbd2.velocity.y);
        }
    }

    public void ChangeDirection()
    {
        Parent.transform.localScale = new Vector3(Parent.transform.localScale.x * -1, Parent.transform.localScale.y, Parent.transform.localScale.z); //odwrocenie bosa
        walkDir = walkDir*(-1); //zmiana keirunku
    }
    public void Damage(int damage)
    {
        curentHealth -= damage; //zadawnie obrazne bosowi
        anim.GetComponent<Animation>().Play("player_RedFlash"); //aniamcja dostowania obrazen
        if (curentHealth <= 0) //zniszczenie bosa i wywalanie animacji gdy ma 0 hp
        {
           anim.GetComponent<Animator>().SetInteger("CurrHp",0);
           Feet.transform.position = new Vector3(Feet.transform.position.x, -0.5f, Feet.transform.position.z);
           Destroy(gameObject.GetComponent<Collider2D>());
           Destroy(FrontCol);
           Destroy(BackCol);
           Destroy(Mele);
           DoorToOpen2.GetComponent<Animator>().SetBool("AreOpen",true);
        }
    }


}
