using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnDecor : MonoBehaviour
{
    [SerializeField]
    public GameObject decorPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;
    private float spawnTime;
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


    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
        GameObject decorObject = ObjectPool.instance.GetPoolObject();

        if (decorObject != null)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            decorObject.transform.position = transform.position + new Vector3(x, y, 0);
            decorObject.transform.rotation = transform.rotation;
            decorObject.SetActive(true);

            StartCoroutine(DeactivateWhenOffScreen(decorObject));
        }
    }

    private IEnumerator DeactivateWhenOffScreen(GameObject decorObject)
    {
        // Wait for one frame to ensure the object is rendered before checking if it's off-screen
        yield return null;

        while (IsOffScreen(decorObject))
        {
            decorObject.SetActive(false);
            yield return null;
        }
    }

    private bool IsOffScreen(GameObject obj)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(obj.transform.position);
        return screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height;
    }

}
