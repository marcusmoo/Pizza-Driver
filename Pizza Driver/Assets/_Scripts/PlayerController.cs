using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed;
    public float boostSpeed;
    public float damagedSpeed;
    public float rotateMulti;
    float currSpeed;
    float isMoving;
    
    bool hasBluePizza;
    bool hasRedPizza;

    public SpriteRenderer playerSprite;
    public Color32 hasBluePizzaColour;
    public Color32 hasRedPizzaColour;
    public Color32 defaultColour;

    public AudioSource hitSomething;

    // Start is called before the first frame update

    void Start()
    {
        currSpeed = baseSpeed;
        hasBluePizza = false;
        hasRedPizza = false;
        
        playerSprite.color = defaultColour;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("up"))
        {
            isMoving = 1;
            transform.Translate(0, currSpeed, 0);
        }

        // Reverse dif makes the car reverse slower
        if (Input.GetKey("down"))
        {
            isMoving = 1;
            transform.Translate(0, -currSpeed, 0);
        }


        // If the car is not moving it will not rotate
        if (!Input.GetKey("up") && !Input.GetKey("down"))
        {
            isMoving = 0;
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0, -currSpeed * rotateMulti * isMoving);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, 0, currSpeed * rotateMulti * isMoving);
        }

    }

    public IEnumerator Boost()
    {
        
        yield return new WaitForSeconds(0.18f);
        currSpeed = boostSpeed;
        yield return new WaitForSeconds(2f);
        currSpeed = baseSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
            currSpeed = damagedSpeed;
            hitSomething.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BluePizza" && hasRedPizza == false && hasBluePizza == false)
        {
            playerSprite.color = hasBluePizzaColour;
            hasBluePizza = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "RedPizza" && hasRedPizza == false && hasBluePizza == false)
        {
            playerSprite.color = hasRedPizzaColour;
            hasRedPizza = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "BlueZone" && hasBluePizza == true)
        {
            playerSprite.color = defaultColour;
            hasBluePizza = false;
        }

        if (other.tag == "RedZone" && hasRedPizza == true)
        {
            playerSprite.color = defaultColour;
            hasRedPizza = false;
        }

        if (other.tag == "Boost")
        {
            Destroy(other.gameObject);
            StartCoroutine(Boost());
        }
    }
}