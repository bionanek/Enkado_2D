using UnityEngine;
using System.Collections;

public class groundCheck : MonoBehaviour   //to sluzy tlyko do oksreslania czy gracz dotyka ziemi
{
    private player _player;
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
