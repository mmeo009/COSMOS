using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] level_1;
    public GameManager GM;
    public float speed;
    public int level;
    private void Start()
    {
        GM = GameManager.Instance;
        MapGen(level, 0);
        MapGen(level, 20);
        MapGen(level, 40);
    }
    public void MapGen(int level, float amount)
    {
        Debug.Log("�����?");
        switch(level)
        {
            case 1:
                int Lv1num = Random.Range(0, level_1.Length);
                GameObject temp = (GameObject)Instantiate(level_1[Lv1num]);
                temp.transform.position = new Vector2 (amount,0);
                Debug.Log("1�� ���� ����");
                break;
        }

    }
}
