using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRtL : MonoBehaviour
{
    public string poolTag;
    public float speed = 5;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= speed * Time.fixedDeltaTime;
        transform.position = pos;
    }
    private IEnumerator DeactivateObjectAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
