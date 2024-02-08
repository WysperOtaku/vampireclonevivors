using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyN1 : MonoBehaviour
{
    private float velocidadE = 2.5f;
    private GameObject player;
    private float vidaEn1 = 3;
    public static int killslvl1;
    private float dañoP = 1f;
    public SpriteRenderer healthBar;
    public Transform healthBarTransform;
    public int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Placeholder de barra de vida luego se cambia */ float healthPercentage = (float)vidaEn1 / maxHealth;
        healthBarTransform.transform.localScale = new Vector3(healthPercentage * 5, 1, 1);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BalaP") || collision.gameObject.CompareTag("Player"))
        {
            vidaEn1 -= dañoP + Player.nuevoDaño;
            if (vidaEn1 <= 0)
            {
            Destroy(this.gameObject);
            killslvl1++;
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
