using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecor : MonoBehaviour
{
    [SerializeField] GameObject[] decorPrefab;
    [SerializeField] float secondSpawn = 4f;
    [SerializeField] float minTrans;
    [SerializeField] float maxTrans;

    void Start()
    {
        StartCoroutine(DecorSpawner());
    }

    IEnumerator DecorSpawner()
    {
        while (true)
        {
            var wanted = Random.Range(minTrans, maxTrans);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(decorPrefab[Random.Range(0, decorPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }

    //[SerializeField] GameObject[] decorPrefab;
    //public float maxX;
    //public float minX;
    //public float maxY;
    //public float minY;
    //public float TimebetweenSpawn;
    //public float SpawnTime;

    //private void Update()
    //{

    //}

    //void Spawn()
    //{
    //    float x = Random.Range(minX, maxX);
    //    float y = Random.Range(minY, maxY);

    //    Instantiate(decorPrefab, transform.position + new Vector3(x, y, 0), transform.rotation);
    //}
}
