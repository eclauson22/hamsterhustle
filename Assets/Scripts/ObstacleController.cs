using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject twigPrefab;
    public GameObject rockPrefab;
    public GameObject cheesePrefab;
    public GameObject carrotPrefab;
    public GameObject redbullPrefab;

    public Transform wheel;
    public float spawnDistance = 3f;
    public float spawnHeight = 1f;

    public float obstacleProbability = 0.7f; // Probability of spawning an obstacle (vs. a power-up)
    public float redbullProbability = 0.2f;

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
        GameObject collectiblePrefab;
        float randomValue = Random.value;
        if (randomValue < 0.6f)
        {
            // Spawn a bad object
            collectiblePrefab = Random.value < 0.5f ? twigPrefab : rockPrefab;
        }
        else
        {
            // Spawn a power-up
            float powerUpRandomValue = Random.value;
            if (powerUpRandomValue < 0.2f)
            {
                // Spawn a red bull
                collectiblePrefab = redbullPrefab;
            }
            else if (powerUpRandomValue < 0.6f)
            {
                // Spawn cheese
                collectiblePrefab = cheesePrefab;
            }
            else
            {
                // Spawn carrot
                collectiblePrefab = carrotPrefab;
            }
        }

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

        string type = collectiblePrefab == twigPrefab || collectiblePrefab == rockPrefab ? "Obstacle" : "Power-up";
        Debug.Log(type + " spawned in lane: " + laneOffset);

        // Destroy the collectible after 10 seconds
        Destroy(collectibleInstance, 12f);
    }



    // Update called once per frame
    void Update()
    {
        // Don't need to update the position of the obstacles here
        // - They'll move with the wheel because they're children of the wheel
    }
}



