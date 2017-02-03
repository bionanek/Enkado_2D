using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public int IndexOfLevelToLoad;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            gm.InputText.text = ("[E] to Enter"); //przelsanie do gamemaster informacji ktora ma wyswietlic
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player"))
        {
            if (Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene(IndexOfLevelToLoad); //zaladowanie sceny
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
