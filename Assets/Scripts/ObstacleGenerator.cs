using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject twigPrefab;
    public GameObject rockPrefab;
    public GameObject cheesePrefab;
    public GameObject carrotPrefab;
    public GameObject redbullPrefab;
    public GameObject ballOfDeathPrefab;
    public GameObject ultimateObstaclePrefab; // obstacle for level 3

    public Transform wheel;
    public float spawnDistance = 3f;
    public float spawnHeight = 1f;

    public float obstacleProbability = 0.7f; // Probability of spawning an obstacle (vs. a power-up)
    public float redbullProbability = 0.2f;
    public float spawnInterval = 1.5f;

    private static bool hasStarted = false;

    void Start()
    {
        if (!hasStarted)
        {
            InvokeRepeating("GenerateObstacle", 0f, spawnInterval);
            hasStarted = true;

            Debug.Log("Started");
        }
    }


    void GenerateObstacle()
    {

        // Default spawn position
        Vector3 fixedSpawnPosition = new Vector3(50f, 14.5f, 23f);


        // Randomly determine if we should spawn an obstacle or a power-up
        GameObject collectiblePrefab;
        float randomValue = Random.value;

        // 50% chance of spawning an obstacle, as opposed to a power-up
        if (randomValue <= 0.75f)
        {
            // Spawn an obstacle: equal chance of spawning each obstacle prefab
            // Adjusting index range based on level
            int randomIndex = Random.Range(0, GameManager.Instance.currentLevel >= 3 ? 4 : GameManager.Instance.currentLevel == 2 ? 3 : 2); 

            if (randomIndex == 0){
                collectiblePrefab = twigPrefab;
            }
            else if (randomIndex == 1){
                collectiblePrefab = rockPrefab;
            }
            else if (randomIndex == 2)
            {
                collectiblePrefab = ballOfDeathPrefab;
            }
            else
            {
                collectiblePrefab = ultimateObstaclePrefab;
            }

        }
        else
        {
            // Spawn a power-up

            float powerUpRandomValue = Random.value;
            if (powerUpRandomValue <= 0.4f)
            {
                // Spawn a red bull
                collectiblePrefab = redbullPrefab;
                fixedSpawnPosition = new Vector3(50f, 14.5f, 20f);
                    }
            // Normal power-up (non-redbull)
            else
            {
             
                if (powerUpRandomValue <= 0.6f)
                {
                    // Floating (need to jump to get)
                    fixedSpawnPosition = new Vector3(50f, 14.5f, 22f);

                    // Spawn cheese: 40% chance out of power-up pool
                    collectiblePrefab = cheesePrefab;


}
                else
                {
                    // Resting on bottom of wheel
                    fixedSpawnPosition = new Vector3(50f, 14.5f, 23.5f);

                    // Spawn carrot: 40% chance out of power-up pool
                    collectiblePrefab = carrotPrefab;

                }
            }
        }

        Quaternion rotation = collectiblePrefab == carrotPrefab ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        // Instantiate the collectible at the fixed spawn position
        GameObject collectibleInstance = Instantiate(collectiblePrefab, fixedSpawnPosition, rotation);

        // Tie/parent the collectible to the wheel 
        collectibleInstance.transform.parent = wheel;

        // Rotate the collectible 90 degrees around the x-axis
        collectibleInstance.transform.Rotate(Vector3.right, 90f);

        // Randomly offset the collectible to one of the lanes
        int laneOffset = Random.Range(-4, 6);

        // Position the collectible in one of the randomized lanes
        Vector3 collectiblePosition = fixedSpawnPosition + Vector3.right * laneOffset;
        collectibleInstance.transform.position = collectiblePosition;

        // string type = collectiblePrefab == twigPrefab || collectiblePrefab == rockPrefab ? "Obstacle" : "Power-up";
        // Debug.Log(type + " spawned in lane: " + laneOffset);

    }
}

