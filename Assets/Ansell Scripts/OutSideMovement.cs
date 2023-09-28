using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSideMovement : MonoBehaviour

{

    public float wSpeed;
    public float xDirection;
    public float xVector;
    public float yDirection;

    public float yVector;

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

        yDirection = Input.GetAxis("Vertical");
        yVector = yDirection * wSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(0,yVector, 0);
    }
}