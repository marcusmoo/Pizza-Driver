using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    
    public Text timeText, packagesLeftText, winText;
    public int packagesLeft;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerController>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeText.text = "Timer: " + timer.ToString("F1");

        if (packagesLeft == 0)
        {
            Time.timeScale = 0;
            winText.text = "You delivered all the pizza" +
                "\n Thank you for playing!";
              
        }
    }

    public void UpdateDeliveries()
    {
        packagesLeft -= 1;
        packagesLeftText.text = "Pizzas Left: " + packagesLeft;
    }


}
