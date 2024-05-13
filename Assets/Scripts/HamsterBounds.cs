using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterBounds : MonoBehaviour
{
    private Vector3 origin = new Vector3(50f, 3.65f, 12.24f);

    private float maxLeftPosition;
    private float maxRightPosition;

    private float minVertPosition;
    private float maxVertPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize maxLeftPosition and maxRightPosition
        maxLeftPosition = origin.x - 4f;
        maxRightPosition = origin.x + 4f;
        minVertPosition = origin.y;
        maxVertPosition = origin.y + 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, maxLeftPosition, maxRightPosition);
        viewPos.y = Mathf.Clamp(viewPos.y, minVertPosition, maxVertPosition);
        transform.position = viewPos;
    }
}
