using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecor : MonoBehaviour, IObjectPool
{
    [SerializeField]
    public GameObject decorPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float TimeBetweenSpawn;
    private float SpawnTime;
    public string poolTag;
    void Update()
    {
        if (Time.time > SpawnTime)
        {
            OnObjectSpawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    public void OnObjectSpawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);


        GameObject spawnedObject = ObjectPool.Instance.SpawnFromPool(poolTag, transform.position + new Vector3(x, y, 0), transform.rotation);
        StartCoroutine(DeactivateObjectAfterDelay(spawnedObject, 6f));
    }

    private IEnumerator DeactivateObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
