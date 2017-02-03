using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour {

	public int damage = 20;

	void OnTriggerEnter2D(Collider2D col)
	{

		if (!col.isTrigger && col.CompareTag("Enemy")||col.CompareTag("DestroyableWall"))
		{
			col.SendMessageUpwards("Damage",damage);
			Destroy (gameObject);
		}
		if (!col.isTrigger && !col.CompareTag ("Enemy")) 
		{
			Destroy (gameObject);
		}
	}
}
