using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartsSprites;
    public Image HeartUI;

    public Sprite[] EssenceEarthSprites;
    public Image EssenceEarthImage;

    public Sprite[] EssenceWaterSprites;
    public Image EssenceWaterImage;

    public Sprite[] EssenceWindSprites;
    public Image EssenceWindImage;

    public Sprite[] EssenceFireSprites;
    public Image EssenceFireImage;

    public Sprite[] FlashSprites;
    public Image FlashImage;

    private player Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").GetComponent<player>(); //pobranie skyrptu player
    }

    void Update() //meotdy aktualizujace wyglad
    {
        heartPoints();
        EssenceEarthPoint();
        EssenceWindPoint();
        EssenceFirePoint();
        EssenceWaterPoint();
        FlashPoint();
    }
    //wsyztskie metody ponizej pobieraja z  skryptu player obecny stan gracza i ustawiaja wyglad na podstawie tych danych

    private void EssenceEarthPoint()
    {
        try
        {
            EssenceEarthImage.sprite = EssenceEarthSprites[Player.curEssenceEarth];
        }
        catch (Exception)
        {
            EssenceEarthImage.sprite = EssenceEarthSprites[1];
        }
    }
    private void EssenceWaterPoint()
    {
        try
        {
            EssenceWaterImage.sprite = EssenceWaterSprites[Player.curEssenceWater];
        }
        catch (Exception)
        {
            EssenceWaterImage.sprite = EssenceWaterSprites[1];
        }
    }
    private void EssenceWindPoint()
    {
        try
        {
            EssenceWindImage.sprite = EssenceWindSprites[Player.curEssenceWind];
        }
        catch (Exception)
        {
            EssenceWindImage.sprite = EssenceWindSprites[1];
        }
    }
    private void EssenceFirePoint()
    {
        try
        {
            EssenceFireImage.sprite = EssenceFireSprites[Player.curEssenceFire];
        }
        catch (Exception)
        {
            EssenceFireImage.sprite = EssenceFireSprites[1];
        }
    }

    private void heartPoints()
    {
        try
        {
            HeartUI.sprite = HeartsSprites[Player.curHealth];
        }
        catch (Exception)
        {
            HeartUI.sprite = HeartsSprites[0];
        }
    }

    private void FlashPoint()
    {
        try
        {
            FlashImage.sprite = FlashSprites[Player.curFlash];
        }
        catch (Exception)
        {
            FlashImage.sprite = FlashSprites[1];
        }
    }
}
