using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;

public class OutSideMovement : MonoBehaviour

{
    public bool Overworld;
    public float wSpeed;
    public float xDirection;
    public float xVector;
    public float yDirection;
    public bool shouldJump;
    public bool canJump;
    public float jumpSpeed;
    public float yVector;
    private Vector3 playerInput;
    public Rigidbody2D rb;
    public GameObject player;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        wSpeed = 5f;
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()


    {

        if (Overworld)
        {
            xDirection = Input.GetAxis("Horizontal");
            xVector = xDirection * wSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(xVector, 0);

            yDirection = Input.GetAxis("Vertical");
            yVector = yDirection * wSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(0, yVector);
        }
        else

        {
            playerInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
 
            if(canJump && Input.GetKeyDown(KeyCode.Space))
            {
                canJump = false;
                shouldJump = true;
            }

  
        } 

    }

    
    private void FixedUpdate()
    {
        // move
        if(playerInput != Vector3.zero) {
            rb.AddForce(playerInput * wSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
     
        // jump
        if(shouldJump) {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            shouldJump = false;
        }
    }
 
    private void OnCollisionEnter2D(Collision2D collider)
    {
        // allow jumping again
        canJump = true;
    }
 
    private void OnCollisionExit2D(Collision2D colldier)
    {
        player.transform.tag = "Jumping";
    }
}

           
        
    

