using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour { //klasa od zakelcia wiatr

    public int damage = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", damage); //wyslanie wiaodmsoci ze ma zadac obrezenie
            if (col.GetComponentInParent<Rigidbody2D>() != null) //sprawdzenie czy napewno ma cialo
            {
                col.GetComponentInParent<par>().post(); //podrzucenie przeciwnika ktory ma skyrpt par
            }
            Destroy(gameObject);
        }
        if (!col.isTrigger && !col.CompareTag("Enemy") && !col.CompareTag("Bullet") && !col.CompareTag("player") && !col.CompareTag("PlayerFeet")) //wylaczenie reagowania 
        {
            Destroy(gameObject); //znieszczenie siebei gdy dotknie co kolwiek innego niz wrog
        }
    }
}
