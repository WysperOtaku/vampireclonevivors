using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupPlayer : MonoBehaviour
{
    public GameObject panelPowerup;
    // Start is called before the first frame update
    void Start()
    {
        panelPowerup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
            panelPowerup.SetActive(true);
        }
    }
}
