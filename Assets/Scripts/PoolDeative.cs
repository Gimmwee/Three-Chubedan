using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDeative : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (!IsOnScreen())
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private bool IsOnScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.x > 0 && screenPosition.x < 1 && screenPosition.y > 0 && screenPosition.y < 1;
    }
}
