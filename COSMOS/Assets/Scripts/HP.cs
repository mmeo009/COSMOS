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
        currentHP = maxHP;  // ���� �� ü���� �ִ� ü������ ��������
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        hpSlider.value = currentHP;
    }

    // ü�� ���� �� ȣ���ϴ� �Լ�
    public void ModifyHP(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        UpdateHPBar();

      
        if (currentHP <= 0)    // ü���� 0 ���Ϸ� �������� ó���� ���� �߰�~
        {

            GameManager.Instance.GameOver();
        }
    }
}
