using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
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
   

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Fireball"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                Destroy(other.gameObject);
                iframes = true;
            }
            
            
        }
    }





    void ChangeHealth(int amount)
    {
        hud.health += amount;
        Debug.Log("Health: " + hud.health);

    }

    
}

