using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesPowerUp : MonoBehaviour
{
    public GameObject panelPowerup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PowerUp1()
    {
        Player.nuevoDaño += 0.5f;
        panelPowerup.SetActive(false);
        Time.timeScale = 1;
    }
    public void PowerUp2()
    {
        //dar power up
        panelPowerup.SetActive(false);
        Time.timeScale = 1;
    }
    public void PowerUp3()
    {
        //dar power up
        panelPowerup.SetActive(false);
        Time.timeScale = 1;
    }
}