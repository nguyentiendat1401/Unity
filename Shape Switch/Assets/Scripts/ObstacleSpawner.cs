using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float timeBetweenSpawns;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform.position, Quaternion.identity);

        Invoke("Spawn", timeBetweenSpawns);
    }
}
