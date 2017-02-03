using UnityEngine;
using System.Collections;

public class MoveIceBLock : MonoBehaviour { //blokowanie pozycji klocka lodowego
	void Update ()
	{
	    if (transform.position.x > 17.5f)
	       gameObject.transform.position=new Vector3(17.5f,transform.position.y,0);
        if (transform.position.x < -2.5f)
            gameObject.transform.position = new Vector3(-2.5f, transform.position.y, 0);
    }
}
