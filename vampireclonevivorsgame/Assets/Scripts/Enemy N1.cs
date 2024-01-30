using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyN1 : MonoBehaviour
{
    private float velocidadE = 2.5f;
    private GameObject player;
    private int vidaEn1 = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BalaP"))
        {
            vidaEn1--;
            if (vidaEn1 <= 0)
            {
            Destroy(this.gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 direccion = (player.transform.position - transform.position).normalized;
            Vector2 velocidadireccion = GetComponent<Rigidbody2D>().velocity = direccion * velocidadE;
        }
        if (player == null)
        {
            Vector3 direccion = (player.transform.position - transform.position).normalized;
            Vector2 velocidadireccion = GetComponent<Rigidbody2D>().velocity = direccion * 0;
        }
    }
}
