using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public int initialForceMultiplier = 100;
    public GameObject cam;

    private Camera camComponent;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        camComponent = cam.GetComponent<Camera>();

        //pick random direction for the ball to go
        Vector3 initialDirection = new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f, 1.0f),0);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialDirection * initialForceMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = camComponent.WorldToScreenPoint(transform.position);

        //ball goes out ouf bounds
        if(screenPosition.x <= 0 || screenPosition.y <= 0 || screenPosition.x >= Screen.width || screenPosition.y >= Screen.height)
        {
            //rb.AddForce(rb.velocity);
            //I am confusion

        }
        //Debug.Log("Screen Width" + Screen.width );

    }
}
