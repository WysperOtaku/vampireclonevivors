using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    private int totalEnemiesToSpawn = 10;
    private float radius = 20f;
    private int generationCount = 0;
    public GameObject mapLowerLeftCorner;
    public GameObject mapUpperRightCorner;
    private void Start()
    {
        SpawnEnemies();
    }
    private void SpawnEnemies()
    {
        generationCount++;
        for (int i = 0; i < totalEnemiesToSpawn; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnCircle();
            GameObject randomEnemyPrefab;
            if (generationCount >= 3)
            {
                randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            }
            else
            {
                randomEnemyPrefab = enemyPrefabs[0];
            }
            Instantiate(randomEnemyPrefab, randomPosition, Quaternion.identity);
        }
    }
    private Vector3 GetRandomPositionOnCircle()
    {
        Vector3 randomPoint;
        int attempts = 0;
        do
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            randomPoint = new Vector3(x, y, 0f) + transform.position;
            attempts++;
            if (attempts > 1000)
            {
                radius *= 0.9f; // reduce the radius by 10%
                attempts = 0;
            }
        } while (!IsWithinMapBounds(randomPoint));

        return randomPoint;
    }

    private bool IsWithinMapBounds(Vector3 point)
    {
        return point.x >= mapLowerLeftCorner.transform.position.x && point.x <= mapUpperRightCorner.transform.position.x &&
            point.y >= mapLowerLeftCorner.transform.position.y && point.y <= mapUpperRightCorner.transform.position.y;
    }
        private bool AllEnemiesDead()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }
    private void Update()
    {
        if (AllEnemiesDead())
        {
            SpawnEnemies();
        }
    }
}
