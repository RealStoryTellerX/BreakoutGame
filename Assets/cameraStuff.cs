using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraStuff : MonoBehaviour
{
    public Transform ballPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = GetComponent<Camera>().WorldToScreenPoint(ballPosition.position);
        Debug.Log(screenPosition);

    }
}
