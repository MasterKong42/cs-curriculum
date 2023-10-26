using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCode : MonoBehaviour
{
    private float ipotion;
    private float iframesTimer;
    private float iframesTimerDefault = 1.5f;
    private bool iframes = false;


    public HUD hud;

    // Start is called be   fore the first frame update
    void Start()
    {
        iframesTimer = iframesTimerDefault;
        hud = FindObjectOfType<HUD>();
    }

    private void Update()
    {
        if (iframes)
        {
            iframesTimer -= Time.deltaTime;
            if (iframesTimer < 0)
            {
                iframes = false;
                //reset the timer
                iframesTimer = iframesTimerDefault;
            }
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }

            if (hud.health < 1)
            {
                Death();
            }


        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!iframes)
            {
                ChangeHealth(-2);
                iframes = true;
            }

            if (hud.health < 1)
            {
                Death();
            }


        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Fireball"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Potion"))
        {
            ChangeHealth(1);
            Destroy(other.gameObject);
            Debug.Log("You found a Red Potion, those heal you!");

        }
        
        if (other.gameObject.CompareTag("IPotion"))
        {

            iframesTimer = 10f;
            iframes = true;
            Destroy(other.gameObject);
            Debug.Log("You found a Blue Potion, those give you invincibility for 10 seconds");

        }
    
    }

    void Death()
    {
        hud.coins = 0;
        hud.health = 10;

        SceneManager.LoadScene("Start", LoadSceneMode.Single);
        Debug.Log("You died :( . . . Your Coins  have been rest to ZERO and your Health back to TEN! ");
    }



    void ChangeHealth(int amount)
    {
        hud.health += amount;
        Debug.Log("Health: " + hud.health);

    }
}

   