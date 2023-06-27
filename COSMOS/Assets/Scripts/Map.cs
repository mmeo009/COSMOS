using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapSystem;
    public GameManager GM;
    public int level;
    float speed;
    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        mapSystem = GameObject.FindGameObjectWithTag("MapGen").gameObject;
    }
    private void FixedUpdate()
    {
        speed = -GM.speed;
        this.transform.Translate(Vector3.right * speed);
    }

    private void Update()
    {
        if(this.transform.position.x <= -20)
        {
            mapSystem.GetComponent<MapGenerator>().MapGen(level, this.transform.position.x + 20);
            Destroy(this.gameObject);
        }
    }
}
