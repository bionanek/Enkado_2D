using UnityEngine;
using System.Collections;

public class Wodspad : MonoBehaviour
{

    public GameObject ice;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "player")
        {
            GameObject wodospad = GameObject.FindGameObjectWithTag("Wodospad");
            Destroy(wodospad);
            Instantiate(ice,wodospad.transform.position,wodospad.transform.rotation);

        }

    }



}
