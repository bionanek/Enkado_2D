using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public int point;
    public Text PointText;
    public Text InputText;

    void Update()
    {
        PointText.text = ("Points : " + point);
    }
}
