using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnDistance = 15f;
    public float spawnHeight = 0f;

    private static bool hasStarted = false;

    void Start()
    {
        if (!hasStarted)
        {
            InvokeRepeating("GenerateObstacle", 0f, 2f);
            hasStarted = true;
        }
    }

    void GenerateObstacle()
    {
        Vector3 spawnPosition = player.position + player.forward * spawnDistance + Vector3.up * spawnHeight;
        GameObject obstacleInstance = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        float randomOffset = Random.Range(-5f, 5f);
        obstacleInstance.transform.Translate(Vector3.right * randomOffset);
    }

}


