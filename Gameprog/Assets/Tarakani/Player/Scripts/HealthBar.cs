using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Movement player;
    
    Image healthBar;
    
    public float maxHP = 10;
    

    void Start()
    {
        healthBar = GetComponent<Image>();
        maxHP = player.HP;
    }

    void Update()
    {
        healthBar.fillAmount = player.HP / maxHP;
    }
}
