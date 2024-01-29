using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public List<BoxCollider2D> mapBounds; // Lista de BoxCollider2D que representan los límites del mapa
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - jugador.position;
    }

    void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 desiredPosition = jugador.position + offset;

            // Calcula la mitad del tamaño de la cámara
            float camHalfHeight = UnityEngine.Camera.main.orthographicSize;
            float camHalfWidth = UnityEngine.Camera.main.aspect * camHalfHeight;

            // Verifica si la nueva posición está dentro de los límites de cualquiera de los BoxCollider2D del mapa
            foreach (BoxCollider2D bounds in mapBounds)
            {
                // Ajusta los límites del mapa para tener en cuenta el tamaño de la cámara
                float minX = bounds.bounds.min.x + camHalfWidth;
                float maxX = bounds.bounds.max.x - camHalfWidth;
                float minY = bounds.bounds.min.y + camHalfHeight;
                float maxY = bounds.bounds.max.y - camHalfHeight;

                if (desiredPosition.x >= minX && desiredPosition.x <= maxX && desiredPosition.y >= minY && desiredPosition.y <= maxY)
                {
                    // Si la nueva posición está dentro de los límites, ajusta la posición para que se mantenga dentro de los límites
                    desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
                    desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
                    break;
                }
            }

            transform.position = desiredPosition;
        }
    }
}
