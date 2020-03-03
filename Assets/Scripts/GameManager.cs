using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Hero player = null;
    public Turret turret = null;
    public Text Playertext;
    public Text Turrettext;
    public Text MagicOrbtext;



    // Update is called once per frame
    void Update()
    {
        DisplayProperties();
    }


    void DisplayProperties()
    {
        Playertext.text = "Player Health :"+player.playerHealth.ToString();
        Turrettext.text = "Turret Health :" + turret.turretHealth.ToString();
        MagicOrbtext.text = "MagicOrb Left: " + player.magicOrbAmount.ToString();
    }
}
