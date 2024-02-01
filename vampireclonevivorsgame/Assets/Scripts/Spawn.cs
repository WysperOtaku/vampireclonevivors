using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    private int totalEnemiesToSpawn = 10;
    private float radius = 17.5f;
    private int generationCount = 0;
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
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        Vector3 randomPoint = new Vector3(x, y, 0f) + transform.position;
        return randomPoint;
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
