using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public int initialForceMultiplier = 100;
    public GameObject cam;
    public float EdgeBuffer = 0.1f;
    public ParticleSystem bounceFX;

    private Camera camComponent;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        camComponent = cam.GetComponent<Camera>();

        //pick random direction for the ball to go
        Vector3 initialDirection = new Vector3(UnityEngine.Random.Range(-1.0f,1.0f), UnityEngine.Random.Range(-1.0f, 1.0f),0);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(initialDirection * initialForceMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        // Get screen boundaries with buffer zone
        float screenWidth = Screen.width - EdgeBuffer * Screen.width;
        float screenHeight = Screen.height - EdgeBuffer * Screen.height;

        // Convert screen boundaries to world space
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //if (screenPos.x < EdgeBuffer * Screen.width || screenPos.x > screenWidth)
        //{
        //    // Bounce off left or right edge
        //    rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0);
            
        //    // Particle stuff karthi pls help

        //    //ParticleSystem bounceFXclone = Instantiate(bounceFX);
        //    //bounceFXclone.transform.position = transform.position;
        //    //bounceFXclone.Play();
        //}
        //if (screenPos.y < EdgeBuffer * Screen.height || screenPos.y > screenHeight)
        //{
        //    // Bounce off top or bottom edge
        //    rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
        //}

    }
    void OnCollisionEnter(Collision collision)
    {
        ReflectProjectile(rb, collision.contacts[0].normal);
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        Vector3 _velocity = Vector3.Reflect(rb.velocity, reflectVector);
        rb.velocity = _velocity;
    }
}
