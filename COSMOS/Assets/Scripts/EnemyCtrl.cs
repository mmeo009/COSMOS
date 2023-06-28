using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public bool isDefeated = false;
    public AudioClip Die;
    //private AudioSource audioSource;

    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
    }
    public void Defeat() // 몬스터 주거용
    {
        //audioSource.PlayOneShot(Die);
        Destroy(gameObject);
        isDefeated = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GameManager.Instance.dash == true)
            {
                Destroy(this.gameObject);
            }
            else
            {
                collision.GetComponent<PlayerCtrl>().GetDMG(1);
            }
        }
    }
}
