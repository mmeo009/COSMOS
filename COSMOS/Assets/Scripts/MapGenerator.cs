using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] level_1;
    public float speed = 0.01f;
    private void FixedUpdate()
    {
        speed += 0.001f * Time.fixedDeltaTime;
    }

    public void MapGen(int level, float amount)
    {
        Debug.Log("¸¸µç´Ù?");
        switch(level)
        {
            case 1:
                int Lv1num = Random.Range(0, level_1.Length);
                GameObject temp = (GameObject)Instantiate(level_1[Lv1num]);
                temp.transform.position = new Vector2 (38 - amount,0);
                Debug.Log("1·¦ ¸¸µë È÷È÷");
                break;
        }

    }
}
