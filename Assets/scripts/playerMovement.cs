using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public float minMoveDist = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("Left Pressed");
            transform.SetPositionAndRotation(transform.position - new Vector3(minMoveDist, 0,0), transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Left Pressed");
            transform.SetPositionAndRotation(transform.position + new Vector3(minMoveDist, 0, 0), transform.rotation);
        }


    }
}
