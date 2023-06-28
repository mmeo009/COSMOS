using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int maxHP = 5;  
    public int currentHP;    
    public Slider hpSlider, dashSlider, shoutSlider; 

    

    private void Start()
    {
        currentHP = this.GetComponent<PlayerCtrl>().HP;
        UpdateHPBar();
    }

    public void UpdateHPBar()
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
    }
}
