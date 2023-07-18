using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : PlayerMovement
{
    [Header("SpikeHead Atributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private float checkTimer;
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];
    private bool attacking;

    private void OnEnable()
    {
        Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            //Move spikehead to destination only if attacking
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();
        //check if spikehead see player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);
            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //right
        directions[1] = -transform.right * range; //left
        directions[2] = transform.up * range; //up
        directions[3] = -transform.right * range; //down
    }

    private void Stop()
    {
        destination = transform.position; //don't move
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.gameObject.SetActive(false);
        Stop();
    }
}
