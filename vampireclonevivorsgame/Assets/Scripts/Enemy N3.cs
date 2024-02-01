using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyN3 : MonoBehaviour
{
    public Transform player; 
    public GameObject puntoAtaque;
    private float moveSpeed = 3.5f;
    private float stoppingDistance = 5f;
    void Start()
    {

    }
    void Update()
    {
        if (player != null) //Si el jugador no es nulo
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position); //Calcula la distancia entre el enemigo y el jugador
            if (distanceToPlayer > stoppingDistance) //Si la distancia es mayor que la distancia de parada
            {
                MoveTowardsPlayer(); //Mueve el enemigo hacia el jugador
            }
            else
            {
                StopMoving(); //Deja de moverse
            }

            // Make the enemy look at the player
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
    private void MoveTowardsPlayer() //Mueve el enemigo hacia el jugador
    {
        puntoAtaque.SetActive(false);
        Vector2 direction = (player.position - transform.position).normalized; //Calcula la dirección hacia el jugador
        transform.Translate(direction * moveSpeed * Time.deltaTime); //Mueve el enemigo hacia el jugador
    }
    private void StopMoving() //Deja de moverse
    {
        puntoAtaque.SetActive(true);
        transform.Translate(Vector2.zero); //Deja de moverse
    }
}