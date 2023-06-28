using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int maxHP = 5;
    public float maxDash = 1f;
    public float maxShout = 1f;
    public int currentHP;
    public float currentDash;
    public float currentShout;
    public Slider hpSlider, dashSlider, shoutSlider;

    

    private void Start()
    {
        currentHP = this.GetComponent<PlayerCtrl>().HP;
        currentDash = GameManager.Instance.dashTimer;
        currentShout = this.GetComponent<PlayerCtrl>().shoutTimer;
        UpdateHPBar();
        UpdateDashBar();
        UpdateShoutBar();
    }
    private void Update()
    {
        currentDash = GameManager.Instance.dashTimer;
        currentShout = this.GetComponent<PlayerCtrl>().shoutTimer;
        UpdateDashBar();
    }
    public void UpdateHPBar()
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
    }
    public void UpdateDashBar()
    {
        dashSlider.maxValue = maxDash;
        dashSlider.value = currentDash;
    }
    public void UpdateShoutBar()
    {
        shoutSlider.maxValue = currentShout;
        shoutSlider.value = maxShout;
    }
}
