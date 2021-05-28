using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleUpSpawner : MonoBehaviour
{
    public float spawnTime;
    public float lastSpawn;
    public GameObject poleUp;

    private void Start()
    {
        lastSpawn = Random.Range(1, 3.9f);
    }

    void Update()
    {
        if(Time.time > spawnTime + lastSpawn)
        {
            CreatePoleUp();
        }
    }

    void CreatePoleUp()
    {
        Instantiate(poleUp, transform.position, Quaternion.identity);
        lastSpawn = Random.Range(1, 3.9f);
        spawnTime = Time.time;
    }
}
