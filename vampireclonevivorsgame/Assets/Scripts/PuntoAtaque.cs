using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PuntoAtaque : MonoBehaviour
{
    public GameObject balaPP;
    public Transform puntoAtaque;
    private float velocidadBala = 10f;
    private float cooldownBala = 0.75f;
    private float rangoDisparo = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Disparo", 1f, cooldownBala);
    }
    void Update()
    {

    }
    void Disparo()
    {
        GameObject enemigo = GameObject.FindGameObjectWithTag("Enemy");
        if (enemigo != null)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia <= rangoDisparo)
            {
                Vector3 direccion = (enemigo.transform.position - puntoAtaque.position).normalized;
                GameObject bala = Instantiate(balaPP, puntoAtaque.position, Quaternion.LookRotation(Vector3.forward, direccion));
                Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
                rb.velocity = direccion * velocidadBala;
            }
        }
    }
}