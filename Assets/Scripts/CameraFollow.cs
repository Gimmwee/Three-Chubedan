using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 10f;
    public float yOffset = 0.5f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerMovement.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
