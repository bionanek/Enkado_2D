using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Equipment : MonoBehaviour {

    private GameMaster gm;
    private player Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").GetComponent<player>(); //poobranie skryptu player z obiektu o tagu player
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>(); // pobrnaiie skrytpu gamemaster z obiekty gamemasteer

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))  //klawisz 1 
        {
            if (Player.curHealth < Player.maxHealth && gm.hpPotion > 0)
            {
                Player.curHealth += 10; //ziwkeszenie graczowi hp o 10
                gm.hpPotion--; //zmiiejszenie o 1 potiona w ekiwpiunku
               AudioSource.PlayClipAtPoint(Player.musicArray[0],Player.transform.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //kalwisz 2
        {
            if (Player.curEssenceFire == 0 && gm.firePotion > 0)
            {
                Player.curEssenceFire++;
                gm.firePotion--;
                AudioSource.PlayClipAtPoint(Player.musicArray[0], Player.transform.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) //kalwisz 3
        {
            if (Player.curEssenceEarth == 0 && gm.earthPotion > 0)
            {
                Player.curEssenceEarth++;
                gm.earthPotion--;
                AudioSource.PlayClipAtPoint(Player.musicArray[0], Player.transform.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //klawisz 4
        {
            if (Player.curEssenceWind == 0 && gm.windPotion > 0) 
            {
                Player.curEssenceWind++; //
                gm.windPotion--;
                AudioSource.PlayClipAtPoint(Player.musicArray[0], Player.transform.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) //klawisz 5
        {
            if (Player.curEssenceWater == 0 && gm.waterPotion > 0)
            {
                Player.curEssenceWater++;
                gm.waterPotion--;
                AudioSource.PlayClipAtPoint(Player.musicArray[0], Player.transform.position);
            }
        }
    }
}
