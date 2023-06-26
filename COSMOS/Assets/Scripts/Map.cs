using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapSystem;
    public int level;
    float speed;
    private void Awake()
    {
        mapSystem = GameObject.FindGameObjectWithTag("MapGen").gameObject;
    }
    private void FixedUpdate()
    {
        speed = mapSystem.GetComponent<MapGenerator>().speed;
        this.transform.Translate(Vector3.right * speed);
    }

    private void Update()
    {
        if(this.transform.position.x <= -19 - speed)
        {
            mapSystem.GetComponent<MapGenerator>().MapGen(level);
            Destroy(this.gameObject);
        }
    }
}
