using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //WORK IN PROGRESS, AS OF NOW THIS SCRIPT DOESNT REALLY DO ANYTHING
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Sui");
            collision.rigidbody.AddExplosionForce(2.0f, collision.gameObject.transform.position, 2.0f);
        }
    }
}
