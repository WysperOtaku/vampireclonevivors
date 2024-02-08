using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyN1 : MonoBehaviour
{
    public static float velocidadE = 2.5f;
    public static float velExtra;
    private GameObject player;
    public GameObject powerUp1;
    public GameObject powerUp2;
    private float vidaEn1;
    public float vidaInicial = 3;
    public static float incremento;
    public static int killslvl1 = 0;
    private float dañoP = 1f;
    // Start is called before the first frame update
    void Start()
    {
        vidaEn1 = vidaInicial + incremento;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BalaP"))
        {
            vidaEn1 -= dañoP + Player.nuevoDaño;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            vidaEn1--;
        }
        if (vidaEn1 <= 0)
        {
        Destroy(this.gameObject);
        killslvl1++;
        int randomNumero = Random.Range(1, 21);
        int randomNumero2 = Random.Range(1, 31);
        if (randomNumero2 == 3)
        {
            Instantiate(powerUp2, transform.position, Quaternion.identity);
        }
        else if (randomNumero == 3)
        {
            Instantiate(powerUp1, transform.position, Quaternion.identity);
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
        else if (player == null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
