using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO generate bricks

//Iteration 1: Spawn a fixed number of bricks but make sure they are above the player.
//Once a brick gets destroyed make sure to generate another one to make sure the overall count of the bricks remain the same.

//Iteration 2: Size variability, patterns(use object pools instead of (instantiate/delete)

//Iteration 3: Different behaviors

public class brickedUp : MonoBehaviour
{
    public GameObject brickPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //spawn all the initiial bricks here.
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void brickDestroyed()
    {
        //this method will be called whenever a brick is destroyed
    }
}
