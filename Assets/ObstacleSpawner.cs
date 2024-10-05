using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float spawnDistance = 7f;
    public float moveSpeed = 2f;

    public Transform orbitingCircle;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomAngle = Random.Range(0f, 360f);
        Vector3 spawnPosition = new Vector3(
            Mathf.Cos(randomAngle * Mathf.Deg2Rad) * spawnDistance,
            Mathf.Sin(randomAngle * Mathf.Deg2Rad) * spawnDistance,
            0f
        );

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();
        if (obstacleScript != null)
        {
            obstacleScript.SetTarget(orbitingCircle.position, moveSpeed);
        }
    }
}
