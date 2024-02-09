using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Object = UnityEngine.Object;

public class Orc : MonoBehaviour
{


    public bool isInRange;
    public Transform orctarget;
    public Transform iposition;
    private int OrcHealth;
    private float iframesTimer;
    private float iframesTimerDefault = 1;
    private bool iframes = false;
    private CircleCollider2D collider;
    public GameObject Coin;
    public GameObject HealthSquare;
    private int Number;
    private float numTimer = 0.1f;
    public bool numTimerIsRunning = false;

    
// Start is called before the first frame update
    private void Start()
    {
        iframesTimer = iframesTimerDefault;
        OrcHealth = 5;
        collider = gameObject.GetComponent<CircleCollider2D>();
        collider.radius = 4.5f;
        Number = 1;
        numTimerIsRunning = true;
    }

    private void numberTimerReset()
    {
        numTimer = 0.1f;
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!iframes)
            {
                ChangeOrcHealth(-1);
                iframes = true;
            }

            

        }
       
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            ChangeOrcHealth(-2);
            iframes = true;
            collider.radius = collider.radius + 1;
            
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Fireball"))
        {
            ChangeOrcHealth(-2);
            iframes = true;
            collider.radius = collider.radius + 1;
            Destroy(collision.gameObject);
        
        }

    }

    void ChangeOrcHealth(int amount)
        {
            OrcHealth += amount;
            Debug.Log("OrcHealth: " + OrcHealth);
            if (OrcHealth <= 0)
            {
                Death();
            }
        }
    void ChangeNumber(int amount)
    {
        Number += amount;
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collider.radius = collider.radius + 1.3f;
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            
        }
    }

    void Death()
    {
        print("orc died");
        Destroy(gameObject);
        if (Number == 1)
        {
            Instantiate(HealthSquare, transform.position, transform.rotation);
        }
        if (Number == 2)
        {
            Instantiate(Coin, transform.position, transform.rotation);
        }

        
        
    }

    public float orcSpeed;

    private void Update()
    {
        if (isInRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, orctarget.position, orcSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, iposition.position, orcSpeed * Time.deltaTime);
        }

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
        
        if (numTimerIsRunning)
        {
            numTimer -= Time.deltaTime;

            if (numTimer < 0)
            {
                if (Number == 1)
                {
                    numberTimerReset();
                    ChangeNumber(+1);
                }
                else
                {
                    numberTimerReset();
                    ChangeNumber(-1);
                }
            }
        }
        
        if (OrcHealth < 1)
        {
            Death();
        }

       
    }
    


}
