using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    public float dragCoeffecient = 0.5f;
    public float minMoveDist = 100.0f;


    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    // Update is called once per frame


    /*
     * TODO       
     * implement WASD/ mouse movement
     * 
     */

    /*
     * TODO       
     * implement screen-bounds restriction movement
     * 
     */

    private void Drag()
    {
        if (rb.velocity.magnitude > 0)
        {
            rb.AddForce(rb.velocity * -1 * dragCoeffecient);
        }
    }
    private void FixedUpdate()
    {
        //Drag();
        
    }
    void Update()
    {
        //TODO fix this to use velocities
        if(Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("Left Pressed");
            //transform.SetPositionAndRotation(transform.position - new Vector3(minMoveDist, 0,0), transform.rotation);
            rb.AddForce(new Vector3(-minMoveDist, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Left Pressed");
            //transform.SetPositionAndRotation(transform.position + new Vector3(minMoveDist, 0, 0), transform.rotation);
            rb.AddForce(new Vector3(minMoveDist, 0, 0));

        }


    }
}
