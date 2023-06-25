using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecor : MonoBehaviour
{
    [SerializeField]
    public GameObject decorPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float TimeBetweenSpawn;
    private float SpawnTime;

    void Update()
    {
        if (Time.time > SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    //void Start()
    //{
    //    StartCoroutine(SpawnObjectWithDelay());
    //}

    //private IEnumerator SpawnObjectWithDelay()
    //{
    //    while (true)
    //    {
    //        Spawn();
    //        yield return new WaitForSeconds(4f); 
    //        DestroyImmediate(decorPrefab, true);
    //    }
    //}

    // Update is called once per frame
    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(decorPrefab, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
