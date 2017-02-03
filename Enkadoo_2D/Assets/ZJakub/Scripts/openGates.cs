using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openGates : MonoBehaviour {
    public int IndexOfLevelToLoad;
    private GameMaster gm;
    private Animator doorAnimator;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        doorAnimator = GameObject.FindGameObjectWithTag("gates0").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("player") && gm.keys == 3 && doorAnimator.GetBool("Open"))
        {
            gm.InputText.text = ("[E] to Enter");
        }
        else if (col.CompareTag("player") && gm.keys < 3 && doorAnimator.GetBool("Open"))
        {
            gm.InputText.text = "You need 3 keys to get inside!";
        }
        else if (col.CompareTag("player") && gm.keys == 3 && doorAnimator.GetBool("Close"))
        {
            gm.InputText.text = "First you need to open the gates! (use rock block to keep them opened)";
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player") && gm.keys == 3)
        {
            if (Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene(IndexOfLevelToLoad);
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
