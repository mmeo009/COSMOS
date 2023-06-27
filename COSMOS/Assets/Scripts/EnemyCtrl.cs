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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCtrl player = collision.gameObject.GetComponent<PlayerCtrl>();
        }
    }
    public void Defeat()
    {
        //audioSource.PlayOneShot(Die);
        Destroy(gameObject);        //적을 처치하는 로직~
        isDefeated = true;
    }
}
