using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject powerUpPrefab; 
    public Transform wheel;
    public float spawnDistance = 3f;
    public float spawnHeight = 1f;
    public float obstacleProbability = 0.7f; // Probability of spawning an obstacle (vs. a power-up)


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

        // Randomly determine if we should spawn an obstacle or a power-up
        GameObject collectiblePrefab = Random.value < obstacleProbability ? obstaclePrefab : powerUpPrefab;

        // Instantiate the collectible at the fixed spawn position
        GameObject collectibleInstance = Instantiate(collectiblePrefab, fixedSpawnPosition, Quaternion.identity);

        // Parent the collectible to the wheel
        collectibleInstance.transform.parent = wheel;

        // Rotate the collectible 90 degrees around the x-axis
        collectibleInstance.transform.Rotate(Vector3.right, 90f);

        // Randomly offset the collectible to one of the three lanes
        int laneOffset = Random.Range(-2, 4);

        // Position the collectible in one of the randomized lanes
        Vector3 collectiblePosition = fixedSpawnPosition + Vector3.right * laneOffset;
        collectibleInstance.transform.position = collectiblePosition;

        string type = collectiblePrefab == obstaclePrefab ? "Obstacle" : "Power-up";
        Debug.Log(type + " spawned in lane: " + laneOffset);
    }




    // Update called once per frame
    void Update()
    {
        // Don't need to update the position of the obstacles here
        // - They'll move with the wheel because they're children of the wheel
    }
}



