
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public float spinSpeed = 100f; // Speed of spinning
    public float bobHeight = 0.3f; // Height of bobbing
    public float bobSpeed = 1f; // Speed of bobbing

    private Vector3 localStartPos;

    void Start()
    {
        // Store the local starting position relative to the parent
        localStartPos = transform.localPosition;
    }

    void Update()
    {

        // Bob the power-up up and down

        float newZ = localStartPos.z + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.localPosition = new Vector3(localStartPos.x, localStartPos.y, newZ);
    }
}

