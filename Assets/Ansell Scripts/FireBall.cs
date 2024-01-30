using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    public float destroyDelay = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", destroyDelay);
    }

    //void OnCollisionEnter2D(Collision2D collision)
   // {
       //if (collision.gameObject.CompareTag("MobileEnemy"))
       // {
           // DestroyBullet();
        //}
        
   // }
    

    public float projectileSpeed;
    // Update is called once per frame
    private void Update()
    {
        
        transform.Translate(new Vector2( projectileSpeed*Time.deltaTime,0.0f));
       
        

    }
    void DestroyBullet()
    {
        // Destroy the bullet game object
        Destroy(gameObject);
    }
}
