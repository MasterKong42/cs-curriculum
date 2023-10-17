using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    public GameObject Player;
    public GameObject Fireball ;
    public float timer;
 
    public float inttimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"));
        {
            timer -= Time.deltaTime;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timer < 0) ;
        {
            GameObject projectile = Instantiate(Fireball, transform.position, Quaternion.identity);
            Vector3 target = Player.transform.position;
            projectile.transform.Translate(target);
            timer = inttimer;

        }
        
    }

   
}
