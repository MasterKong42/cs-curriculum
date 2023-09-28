using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour


{
    public float wSpeed;
    public float xDirection;
    public float xVector;
// Start is called before the first frame update
    void Start()
    {
        wSpeed = 5f;
    }

// Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        xVector = xDirection * wSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, 0, 0);
    }

}