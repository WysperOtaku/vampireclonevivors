using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidad = 5f;
    public static float vidaP = 100;
    public static float nuevoDaño;
    public GameObject panelPowerup;
    // Start is called before the first frame update
    void Start()
    {
        EnemyN1.killslvl1 = 0;
        EnemyN2.killslvl2 = 0;
        EnemyN3.killslvl3 = 0;
        EnemyN1.incremento = 0;
        EnemyN2.incremento = 0;
        EnemyN3.incremento = 0;
        nuevoDaño = 0;
        panelPowerup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontal, vertical, 0);
        transform.Translate(movimiento * velocidad * Time.deltaTime);
        if (vidaP >= 100)
        {
            vidaP = 100;
        }
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("BalaE"))
        {
            vidaP--;
            if (vidaP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            panelPowerup.SetActive(true);
        }
        if (collision.gameObject.CompareTag("PowerUp2"))
        {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }
        Destroy(collision.gameObject);
        }
    }
}