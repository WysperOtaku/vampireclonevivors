using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyN3 : MonoBehaviour
{
    public Transform player;
    public GameObject puntoAtaque;
    private float moveSpeed = 3f;
    private float stoppingDistance = 5f;
    void Start()
    {

    }
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer > stoppingDistance)
            {
                MoveTowardsPlayer();
            }
            else
            {
                StopMoving();
            }
        }
    }
    private void MoveTowardsPlayer()
    {
        puntoAtaque.SetActive(false);
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    private void StopMoving()
    {
        puntoAtaque.SetActive(true);
    }
}