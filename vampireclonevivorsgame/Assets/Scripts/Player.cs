using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidad = 5f;
    public int maxHealth = 100;
    public Transform healthBarTransform;
    public SpriteRenderer healthBar;
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

        /*Placeholder de barra de vida luego se cambia */ float healthPercentage = (float)vidaP / maxHealth;
        healthBarTransform.transform.localScale = new Vector3(healthPercentage * 6, 1, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
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
            if (enemigo.GetComponent<EnemyN1>())
            {
                EnemyN1.killslvl1++;
            }
            else if (enemigo.GetComponent<EnemyN2>())
            {
                EnemyN2.killslvl2++;
            }
            else if (enemigo.GetComponent<EnemyN3>())
            {
                EnemyN3.killslvl3++;
            }
            Destroy(enemigo);
        }
        Destroy(collision.gameObject);
        }
    }
}