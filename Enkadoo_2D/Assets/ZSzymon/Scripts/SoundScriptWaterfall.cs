using UnityEngine;
using System.Collections;

public class SoundScriptWaterfall : MonoBehaviour
{
    private GameObject player;
    private AudioSource sound;
    public float range = 5f;

	void Start () {
        player=GameObject.FindGameObjectWithTag("player");
	    sound = GetComponent<AudioSource>();
	}

	void Update ()
	{
        CheckDistance(); //wyywlanie metody
	}

    void CheckDistance() //sprawdzenie odlgelgosci od gracza i wlaczanie muuzyki gdy jest blisko
    {
        if (Vector3.Distance(player.transform.position, transform.position) < range)
        {
            sound.mute = false;
        }
        else
        {
            sound.mute = true;
        }
    }
}
