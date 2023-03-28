using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class screenCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public float thickness = 0.05f;

    void Start()
    {
        // Get screen dimensions
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight * screenAspect;

        // Create colliders for the edges of the screen
        CreateEdgeCollider(new Vector2(-screenWidth / 2f - thickness / 2f, 0), new Vector2(thickness, screenHeight + 2f),"left"); // Left
        CreateEdgeCollider(new Vector2(screenWidth / 2f + thickness / 2f, 0), new Vector2(thickness, screenHeight + 2f),"right"); // Right
        CreateEdgeCollider(new Vector2(0, -screenHeight / 2f - thickness / 2f), new Vector2(screenWidth, thickness - 2f),"bottom"); // Bottom
        CreateEdgeCollider(new Vector2(0, screenHeight / 2f + thickness / 2f), new Vector2(screenWidth, thickness + 2f),"top"); // Top
    }

    void CreateEdgeCollider(Vector2 position, Vector2 size, string tag = "")
    {
        GameObject edge = new GameObject("Edge");
        edge.tag = tag;
        edge.transform.parent = transform;
        edge.transform.localPosition = position;
        BoxCollider collider = edge.AddComponent<BoxCollider>();
        collider.size = new Vector3(size.x,size.y,10.0f) ;
        collider.isTrigger = false;
        Rigidbody rb = collider.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.constraints =    RigidbodyConstraints.FreezePositionX |
                            RigidbodyConstraints.FreezePositionY |
                            RigidbodyConstraints.FreezePositionZ |
                            RigidbodyConstraints.FreezeRotationX |
                            RigidbodyConstraints.FreezeRotationY |
                            RigidbodyConstraints.FreezeRotationZ;
    }
}
