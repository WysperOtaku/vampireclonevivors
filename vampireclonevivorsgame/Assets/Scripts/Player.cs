using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidad = 5f;
    private int vidaP = 100;
    public int maxHealth = 100;
    public Transform healthBarTransform;
    public SpriteRenderer healthBar;
    public static float nuevoDaño;
    // Start is called before the first frame update
    void Start()
    {
        EnemyN1.killslvl1 = 0;
        EnemyN2.killslvl2 = 0;
        EnemyN3.killslvl3 = 0;
        nuevoDaño = 0;
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
    }
}