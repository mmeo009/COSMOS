using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int maxHP = 100;  
    public int currentHP;    
    public Slider hpSlider; 

    

    private void Start()
    {
        currentHP = maxHP;  // 시작 시 체력을 최대 체력으로 설정했음
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        hpSlider.value = currentHP;
    }

    // 체력 변경 시 호출하는 함수
    public void ModifyHP(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        UpdateHPBar();

      
        if (currentHP <= 0)    // 체력이 0 이하로 떨어지면 처리할 로직 추가~
        {

            GameManager.Instance.GameOver();
        }
    }
}
