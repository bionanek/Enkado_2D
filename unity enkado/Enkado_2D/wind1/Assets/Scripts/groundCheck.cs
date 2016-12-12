using UnityEngine;
using System.Collections;

public class groundCheck : MonoBehaviour
{
    private player _player;

	// Use this for initialization
	void Start ()
	{
	    _player = GetComponentInParent<player>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            _player.grounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            _player.grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            _player.grounded = false;
        }
    }
}
