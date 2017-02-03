using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckKeys : MonoBehaviour
{

    public GameObject doors1;
    public GameObject doors2;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>(); //pobrnaie skyrptu
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            if (gm.keys >= 3) //sprawdza cyz mamy 3 klucze
            {
                gm.InputText.text = ("[K] to OPEN gate");
            }
            else
            {
                if (gm.keys < 3)
                {
                    gm.InputText.text = ("Not engouh KEYS to OPEN");
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            if (Input.GetKeyDown("k"))
            {
                doors1.GetComponent<Animator>().SetBool("AreOpen",true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
                gm.InputText.text = ("");
        }
    }
}
