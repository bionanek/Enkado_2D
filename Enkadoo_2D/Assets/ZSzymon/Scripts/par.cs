using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class par : MonoBehaviour {

    public void post() //skrytp do podrzucania spelem wiatr wrogow
    {
        if (transform.localScale.x < 0)
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y + 1f, transform.position.z);
        }
    }
    public void post(float x,float y) //sprawdznie pozycji naszej i bosa żeby nie wypnchal nas za mape po uzyciu ulta
    {
        if (transform.localScale.x < 0)
        {
            if (88f < (transform.position.x + 1f + x) && (transform.position.x + 1f + x) < 118.8f)
            {
                transform.position = new Vector3(transform.position.x + 1f + x, transform.position.y + 1f + y,transform.position.z);
            }
            else if((transform.position.x + 1f + x) > 118.8f)
            {
                transform.position = new Vector3(118.8f, transform.position.y + 1f + y,transform.position.z);
            }
        }
        else
        {
            if (88f < (transform.position.x + 1f + x) && (transform.position.x + 1f + x) < 118.8f)
            {
                transform.position = new Vector3(transform.position.x - 1f + x, transform.position.y + 1f + y,
                    transform.position.z);
            }
            else if((transform.position.x + 1f + x)<88f)
            {
                transform.position = new Vector3(88f, transform.position.y + 1f + y,transform.position.z);
            }
        }
    }

    public void water()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
    }
}
