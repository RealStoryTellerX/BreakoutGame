using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ballMovement : MonoBehaviour
{
    public int initialForceMultiplier = 100;
    public GameObject cam;
    public GameObject playa;

    public float EdgeBuffer = 0.1f;
    public ParticleSystem bounceFX;

    private Camera camComponent;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        camComponent = cam.GetComponent<Camera>();

        //pick random direction for the ball to go
        spawn();
    }

    void spawn()
    {
        transform.position = new Vector3(0.601629972f, 2.0999999f, 11.6999998f);
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        Vector3 initialDirection = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), 0);
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
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Direct(collision.contacts[0].normal);
        }
        else if(collision.collider.gameObject.CompareTag("bottom"))
        {
            spawn();
        }
        else
        {
            ReflectProjectile(collision.contacts[0].normal);
        }
    }

    private void Direct(Vector3 reflectVector)
    {
        if (reflectVector.y == 0 || reflectVector.y <0)
        {
            //ball hit the side of the player
            ReflectProjectile(reflectVector);
            return;
        }

        Vector3 mouseDirection = playa.GetComponent<director>().mouseDirectionVector;
        Vector3 _velocity = Vector3.Reflect(rb.velocity, mouseDirection.normalized + reflectVector.normalized);
        float prevVelocity = _velocity.magnitude;
        //float rando = Random.Range(10.0f, 12.0f);
        //_velocity.Normalize();
        rb.velocity = mouseDirection.normalized * prevVelocity ;
    }

    private void ReflectProjectile(Vector3 reflectVector)
    {
        Vector3 _velocity = Vector3.Reflect(rb.velocity, reflectVector);
        float rando = Random.Range(10.0f, 12.0f);
        _velocity.Normalize();
        rb.velocity = _velocity * rando;
    }
}
