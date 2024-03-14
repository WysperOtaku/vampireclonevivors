using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text Counter1;
    public Text Counter2;
    public Text Counter3;

    public Text PowerUp1;
    public Text PowerUp2;

    public Text WeaponLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();
    }
    void TextUpdate()
    {
        Counter1.text =  EnemyN1.killslvl1.ToString();
        Counter2.text =  EnemyN2.killslvl2.ToString();
        Counter3.text =  EnemyN3.killslvl3.ToString();
        PowerUp1.text =  Player.powerUp1.ToString();
        PowerUp2.text =  Player.powerUp2.ToString();
        WeaponLevel.text =  Player.weaponLevel.ToString();
    }
}
