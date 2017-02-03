using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_script : MonoBehaviour {

    public int damage = 15;
    private bool Attack = true;

    private float TimeToDie = 0.7f;

    void Update()
    {
        TimeToDie -= Time.deltaTime;
        if (TimeToDie < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger && col.CompareTag("Enemy") && Attack)
        {
            col.SendMessageUpwards("Damage", damage); //wyslanie wiaodmsoci ze ma zadac obrezenie
            if (col.GetComponent<Rigidbody2D>() != null) //sprawdzenie czy napewno ma cialo
            {
                col.GetComponent<par>().water(); //podrzucenie przeciwnika ktory ma skyrpt par
                Attack = false;
            }
        }
    }
}
