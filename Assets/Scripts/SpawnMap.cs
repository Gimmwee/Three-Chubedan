using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0f;
    public float limitDis = 100f;
    public float respawnDis = 166f;

    protected void FixedUpdate()
    {
        this.GetDistance();
        this.Spawning();
    }

    protected void Spawning()
    {
        if (this.currentDis < this.limitDis) return;
        Debug.Log("spawning");
        Vector3 position = transform.position;
        position.x += this.respawnDis;
        transform.position = position;
    }

    protected void GetDistance()
    {
        this.currentDis = this.player.position.x - transform.position.x;
    }

}
