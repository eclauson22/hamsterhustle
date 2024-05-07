using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
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
        Vector3 spawnPosition = player.position + player.forward; // * spawnDistance + Vector3.up * spawnHeight; //the commented out code make them above the hamster
        spawnPosition.y -= 1.2f;
        GameObject obstacleInstance = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        int randomOffset = Random.Range(-1, 1); //choose between -1, 0, and 1, for three lanes instead of any float in between -1 and 1. used to also be between -5 and 5
        obstacleInstance.transform.Translate(Vector3.right * randomOffset);// could multiply random_offset by 1.2 or something to increase the size of lanes, more left or more right. -1 becomes -1.3 left or 1 becomes 1.3 right
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -3) * Time.deltaTime;
    }

 

}


