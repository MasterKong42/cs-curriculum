using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveJump : MonoBehaviour
{
    public OutSideMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
       playerMovement  = GameObject.FindObjectOfType<OutSideMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement.canJump = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        //player.transform.tag = "Jumping";
        playerMovement.shouldJump = false;
        
        
    }
}
