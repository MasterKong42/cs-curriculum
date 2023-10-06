using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCode : MonoBehaviour
{
    private float iframesTimer;
    private float iframesTimerDefault = 1.5f;
    private bool iframes = false;
    public int health = 10;

    private Coin coinpurse;

    // Start is called before the first frame update
    void Start()
    {
        iframesTimer = iframesTimerDefault;
        coinpurse = FindObjectOfType<Coin>();
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

            if (health < 1)
            {
                Death();
            }

        }
    }

    void Death()
    {
        coinpurse.Coins = 0;

        SceneManager.LoadScene("Start", LoadSceneMode.Single);
        Debug.Log("You died :( . . . Your Coins  have been rest to ZERO and your Health back to TEN! ");
    }



    void ChangeHealth(int amount)
    {
        health += amount;
        Debug.Log("Health: " + health);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Potion"))
        {
            ChangeHealth(1);
            Destroy(other.gameObject);
            Debug.Log("You found a Red Potion, those heal you!");

        }
    }
}