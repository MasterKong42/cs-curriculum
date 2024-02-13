using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MagicPlatfrom : MonoBehaviour
{
    public float ySpeed = 6f;
    private float originalYPosition;
    private float originalXPosition;
    public bool PlayerOn;
    // Start is called before the first frame update
    void Start()
    {
        originalYPosition = transform.position.y;
        originalXPosition = transform.position.x;
        PlayerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOn == true)
        {
            transform.position -= new Vector3(0f, ySpeed * Time.deltaTime, 0f);

        }
        if (PlayerOn == false)
        {
           
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOn = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOn = false;
        }
    }
    
}
