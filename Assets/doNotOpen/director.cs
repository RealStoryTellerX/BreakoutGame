using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class director : MonoBehaviour
{
    public Vector3 mouseDirectionVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        mouseDirectionVector = worldPoint - transform.position;
        mouseDirectionVector.z = 0;

        if (mouseDirectionVector.y < 0)
        {
            mouseDirectionVector.x = 0;
            mouseDirectionVector.y = 0;
            Debug.DrawLine(transform.position, worldPoint, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, worldPoint, Color.green);

        }

    }
}
