using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public SpriteRenderer zoneSprite;
    public Color32 deliveredColour;

    public GameObject Player;
    private PlayerController playerScript ;
   

    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(playerScript.hasRedPizza == true && this.tag == "RedZone")
        {
            zoneSprite.color = deliveredColour;
            GetComponent<Collider2D>().enabled = false;
        }

        if (playerScript.hasBluePizza == true && this.tag == "BlueZone")
        {
            zoneSprite.color = deliveredColour;
            GetComponent<Collider2D>().enabled = false;
        }

    }
}
