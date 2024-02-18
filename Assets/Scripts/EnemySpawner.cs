using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numberOfEnemies = 3;
    Bounds spawnBounds;
    [SerializeField] GameObject enemyPrefab;
    private void Awake()
    {
        spawnBounds = GetComponent<BoxCollider2D>().bounds;
    }

    public List<GameObject> SpawnEnemies()
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject e = Instantiate(enemyPrefab);
            e.transform.position = GetRandomInBounds(spawnBounds);
            list.Add(e);
        }
        return list;
    }

    Vector2 GetRandomInBounds(Bounds bounds)
    {
        float randX = Random.Range(bounds.min.x, bounds.max.x);
        float randY = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(randX, randY);
    }
}
