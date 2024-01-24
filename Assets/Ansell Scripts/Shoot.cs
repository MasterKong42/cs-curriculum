using UnityEngine;

public class Shoot : MonoBehaviour
{
    private void Start()
    {

        initialTime = 1.5f;
        timer = initialTime;
    }

    public float timer;
    public Transform firePoint;
    public GameObject PlayerProjectile;
    public float initialTime;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
           
        }

        if (timer < 0)
        {
            if (Input.GetKeyDown("space"))
            {
                fire();
            }
        }

    }

    void fire()
    {

        Instantiate(PlayerProjectile, firePoint.position, firePoint.rotation);

        Debug.Log("fire");

        timer = initialTime;

    }
    
}