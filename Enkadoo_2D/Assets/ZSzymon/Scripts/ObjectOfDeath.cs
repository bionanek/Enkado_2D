using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectOfDeath : MonoBehaviour { //skrypt nalozony na coldera do okola calej platformy sluzacy do tego ze restuje gre gdy spaddamy


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //zaladowanie ponownie obecne sceny
        }
    }
}
