using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    private GameObject player;

	// Use this for initialization
	void Start () {
	player=GameObject.FindGameObjectWithTag("player");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX); //gladkie sie porsuzanie kamery za graczem
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position=new Vector3(posX,posY,transform.position.z);
    }
}
