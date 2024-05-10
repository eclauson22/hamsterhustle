using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform wheel;
    public float spawnDistance = 3f;
    public float spawnHeight = 1f;

    private static bool hasStarted = false;

    void Start()
    {
        if (!hasStarted)
        {
            InvokeRepeating("GenerateObstacle", 0f, 2f);
            hasStarted = true;

            Debug.Log("Started");
        }
    }


    void GenerateObstacle()
    {
        // Fixed spawn position
        Vector3 fixedSpawnPosition = new Vector3(50f, 14.5f, 24f); 

        // Instantiating the obstacle at fixed spawn position
        GameObject obstacleInstance = Instantiate(obstaclePrefab, fixedSpawnPosition, Quaternion.identity);

        // Wheel becomes the obstacle's parent
        obstacleInstance.transform.parent = wheel;

        // Rotate the obstacle 90 degrees around the x-axis
        obstacleInstance.transform.Rotate(Vector3.right, 90f);

        // Randomly offset the obstacle to one of the three lanes
        int laneOffset = Random.Range(-2, 4);

        // Putting the obstacle in one of the randomized lanes
        Vector3 obstaclePosition = fixedSpawnPosition + Vector3.right * laneOffset;
        obstacleInstance.transform.position = obstaclePosition;

        Debug.Log("Obstacle spawned at fixed position: " + fixedSpawnPosition + ", in lane: " + laneOffset);
    }



    // Update called once per frame
    void Update()
    {
        // Don't need to update the position of the obstacles here
        // - They'll move with the wheel because they're children of the wheel
    }
}



