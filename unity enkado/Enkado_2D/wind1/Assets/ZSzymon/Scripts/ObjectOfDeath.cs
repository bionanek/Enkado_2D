using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectOfDeath : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
