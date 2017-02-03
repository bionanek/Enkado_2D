using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockPostion : MonoBehaviour { //blokowanie pozycji klocka
	
	// Update is called once per frame
	void Update ()
	{
	    if (transform.position.x > 31f)
	        transform.position=new Vector3(31f,transform.position.y,transform.position.z);
        if (transform.position.x < 23f)
	        transform.position=new Vector3(23f,transform.position.y,transform.position.z);
	}
}
