using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseGateZero : MonoBehaviour
{
    public GameObject gates;
    public GameObject rock;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player" || col.gameObject.tag == "openRock")
        {
            gates.GetComponent<Animator>().SetBool("Open",true);
            gates.GetComponent<Animator>().SetBool("Close", false);
            rock.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "player" || col.gameObject.tag == "openRock")
        {
            gates.GetComponent<Animator>().SetBool("Open", true);
            gates.GetComponent<Animator>().SetBool("Close", false);
            rock.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "player" || col.gameObject.tag == "openRock")
        {
            gates.GetComponent<Animator>().SetBool("Close", true);
            gates.GetComponent<Animator>().SetBool("Open", false);
        }
    }
}
