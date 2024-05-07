using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", 2f);
    }

    void SpawnEnemies()
    {
        float posY = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = posY;

        if (Random.Range(0,2) > 0)
        {
           GameObject asteroidObj = Instantiate(asteroid, temp, Quaternion.identity);
           Destroy(asteroidObj, 10f);
        }
        else
        {
            GameObject enemyObj = Instantiate(enemy, temp, Quaternion.Euler(0f,0f,90f));
            Destroy(enemyObj, 10f);
        }

        Invoke("SpawnEnemies", 2f);
    }
}
