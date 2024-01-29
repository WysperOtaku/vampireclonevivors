using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform jugador;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null)
        {
            transform.position = new Vector3(jugador.position.x + offset.x, jugador.position.y + offset.y, transform.position.z);
        }
    }
}
