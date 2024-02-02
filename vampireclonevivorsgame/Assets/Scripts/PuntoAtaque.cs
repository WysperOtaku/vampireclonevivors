using UnityEngine;

public class PuntoAtaque : MonoBehaviour
{
    public GameObject balaPP;
    public Transform puntoAtaque;
    private float velocidadBala = 10f;
    private float cooldownBala = 0.75f;
    private float rangoDisparo = 10f;

    void Start()
    {
        InvokeRepeating("Disparo", 1f, cooldownBala);
    }
    void Disparo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject enemigoMasCercano = null;
        float distanciaMasCercana = Mathf.Infinity;
        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distanciaMasCercana)
            {
                distanciaMasCercana = distancia;
                enemigoMasCercano = enemigo;
            }
        }

        if (enemigoMasCercano != null && distanciaMasCercana <= rangoDisparo)
        {
            Vector3 direccion = (enemigoMasCercano.transform.position - puntoAtaque.position).normalized;
            GameObject bala = Instantiate(balaPP, puntoAtaque.position, Quaternion.LookRotation(Vector3.forward, direccion));
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            rb.velocity = direccion * velocidadBala;
        }
    }
}
