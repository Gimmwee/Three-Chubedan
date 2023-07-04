using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnDecor : MonoBehaviour, IPooledObject
{
    [SerializeField]
    public GameObject decorPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;
    private float spawnTime;
    public string poolTags;
    //void Update()
    //{
    //    if (Time.time > spawnTime)
    //    {
    //        Spawn();
    //        spawnTime = Time.time + timeBetweenSpawn;
    //    }
    //}

    //void Spawn()
    //{
    //    float x = Random.Range(minX, maxX);
    //    float y = Random.Range(minY, maxY);

    //    Instantiate(decorPrefab, transform.position + new Vector3(x, y, 0), transform.rotation);
    //}

    void Update()
    {
        if (Time.time > spawnTime)
        {
            OnObjectSpawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    public void OnObjectSpawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);


        GameObject spawnedObject = ObjectPool.Instance.SpawnFromPool(poolTags, transform.position + new Vector3(x, y, 0), transform.rotation);

    }
    
    

}
