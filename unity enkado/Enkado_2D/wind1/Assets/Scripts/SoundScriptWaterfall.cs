using UnityEngine;
using System.Collections;

public class SoundScriptWaterfall : MonoBehaviour
{
    private GameObject player;
    private AudioSource sound;
    public float range = 5f;



	// Use this for initialization
	void Start () {
        player=GameObject.FindGameObjectWithTag("player");
	    sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        CheckDistance();
	}

    void CheckDistance()
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
