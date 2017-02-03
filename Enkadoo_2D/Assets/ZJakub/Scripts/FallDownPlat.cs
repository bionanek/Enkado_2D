using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class FallDownPlat : MonoBehaviour
{
    public GameObject rock;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger && col.CompareTag("player"))
        {
            //sluzy do przesuwania platrformy calkowicie gdzie indziej nie ma to nic zwiaznegp z elsem w tym if, fcck logic - > kuba pozdro
            if (transform.parent.CompareTag("FallDownPlat"))
            {
                transform.parent.gameObject.AddComponent<Rigidbody2D>();
            }
            else // sluzy do puszczenia kuli i zniszczenia platformy
            {   //Destroy(transform.parent.gameObject);
                Destroy(transform.parent.gameObject);
                rock.SetActive(true);
            }


        }
    }
}
