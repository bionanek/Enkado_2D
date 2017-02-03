using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainColliderEnemyDragon : MonoBehaviour {

    public GameObject Parent;
    public GameObject anim;
    private Rigidbody2D rgbd2;
    public float maxSpeed;
    public Vector2 walkDir = Vector2.right;
    private int curentHealth;
    public int maxHealth = 100;
    private float TimeToChangeDirection;
    public bool CanWalk;

    // Use this for initialization
    void Start()
    {
        rgbd2 = Parent.GetComponent<Rigidbody2D>(); //pobranie ciala
        curentHealth = maxHealth; //obecne hp = max
        TimeToChangeDirection = 10f; //czas zmiany pozycji w przypadku zbugowania sie moba
    }

    // Update is called once per frame
    void Update()
    {
        if (CanWalk)
        {
            rgbd2.AddForce(walkDir); //poruszanie sie
        }
        
        if (rgbd2.velocity.x > maxSpeed)
        {
            rgbd2.velocity = new Vector2(maxSpeed, rgbd2.velocity.y); //ustawienei stalej predkosci
        }

        if (rgbd2.velocity.x < -maxSpeed)
        {
            rgbd2.velocity = new Vector2(-maxSpeed, rgbd2.velocity.y); //ustawienie stalej predkosci w przeciwnym keirunku
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Boundary")) //jezeli elemnt z ktorego dotknal jest naznacozny tagiem " Boundary"
        {
            ChangeDirection(); //wywolanie metody zmienijacej kierunek mobowi
        }
    }

    void OnTriggerStay2D(Collider2D coll) //gdyby sie zbugowal mob i nie odwrocil po 10f dodaktoo go odwraca
    {

        if (coll.CompareTag("Boundary"))
        {
            TimeToChangeDirection -= Time.deltaTime;
            if (TimeToChangeDirection <= 0)
            {
                ChangeDirection();
            }
        }
    }

    public void ChangeDirection()
    {
        Parent.transform.localScale = new Vector3(Parent.transform.localScale.x * -1, Parent.transform.localScale.y, Parent.transform.localScale.z); //pobiera skale rodzica i poprzez pomonozenie x*-1 odwracamy rodzica w przeciwna storna
        walkDir = walkDir * -1; //zmiana kierunku chodzenia na przeciwna
    }
    public void Damage(int damage)
    {
        curentHealth -= damage; //zmneijszanie hp smoka
        anim.GetComponent<Animation>().Play("player_RedFlash"); //wywolanie animacji ze smok dostal obrazenia
        if (curentHealth <= 0)
        {
            Destroy(Parent.gameObject); //zniszczenie smoka
        }
    }
}
