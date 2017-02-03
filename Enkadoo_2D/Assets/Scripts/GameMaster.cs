using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour //to sluzy tylko do wsywietlanai tekstu 
{

    public int point;
    public int hpPotion;
    public int earthPotion;
    public int windPotion;
    public int waterPotion;
    public int firePotion;
    public int keys;
    public Text KeysText;
    public Text PointText;
    public Text InputText;
    public Text HpPotionText;
    public Text EarthPotionText;
    public Text WindPotionText;
    public Text WaterPotionText;
    public Text FirePotionText;

    void Update()
    {
        PointText.text = ("Points : " + point);
        HpPotionText.text = "x" + hpPotion;
        EarthPotionText.text = "x" + earthPotion;
        WindPotionText.text = "x" + windPotion;
        WaterPotionText.text = "x" + waterPotion;
        FirePotionText.text = "x" + firePotion;
        KeysText.text = "x" + keys;
    }
}