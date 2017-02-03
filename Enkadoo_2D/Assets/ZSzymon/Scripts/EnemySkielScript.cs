using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkielScript : MonoBehaviour
{
    public GameObject Parent;
    public GameObject anim;
    private Rigidbody2D rgbd2;
    public float maxSpeed = 100f;
    private Vector2 walkDir = Vector2.right*140f;
    private int curentHealth;
    public int maxHealth = 100;

    public bool CanWalk;

    // Use this for initialization
    void Start ()
    {
        rgbd2 = Parent.GetComponent<Rigidbody2D>(); //pobranie ciala z rodzica
        curentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CanWalk)
        {
            rgbd2.AddForce(walkDir); //to porusza naszym skzieltem
        }

        if (rgbd2.velocity.x > maxSpeed) //stbalizaowanie predkosci stala predkosc
        {
            rgbd2.velocity = new Vector2(maxSpeed, rgbd2.velocity.y);
        }

        if (rgbd2.velocity.x < -maxSpeed) // to samo
        {
            rgbd2.velocity = new Vector2(-maxSpeed, rgbd2.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Boundary")) // gdy dotknie grnaicy ma zaworcic
        {
            ChangeDirection(); //zmiana keirunku
        }
        if (coll.CompareTag("player")) //gdy wyrkyje gracza ma przyspieszyc zbye go zrzucic
        {
            walkDir=walkDir*20f; //zwieskzenie proedkosci
            maxSpeed = maxSpeed*20; //ziweskzenei maksymalej predkosci
        }
    }

    public void ChangeDirection() //odwrocenie i zmiana keirunku predkosci
    {
        Parent.transform.localScale = new Vector3(Parent.transform.localScale.x * -1, Parent.transform.localScale.y, Parent.transform.localScale.z);
        walkDir = walkDir * -1;
    }
    public void Damage(int damage) //dostawanie orbazen i wywolanei animacji 
    {
        curentHealth -= damage;
        anim.GetComponent<Animation>().Play("player_RedFlash");
        if (curentHealth <= 0)
        {
            Destroy(Parent.gameObject); //zniszczenie gdy ma 0 hp
        }
    }
}
