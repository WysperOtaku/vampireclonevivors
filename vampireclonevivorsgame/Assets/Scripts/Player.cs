using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidad = 5f;
    private int vidaP = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontal, vertical, 0);
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            vidaP--;
            if (vidaP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}