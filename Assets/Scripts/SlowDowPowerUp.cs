using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDowPowerUp : MonoBehaviour
{
    //public float slowDownFactor = 0.1f; // H? s? làm ch?m t?c ?? (0.5 = ch?m l?i 50%)
    //public float slowDownDuration = 5; // Th?i gian làm ch?m (3 giây)
    public float initialMoveSpeed = 4f;
    public float maxMoveSpeed = 30f;
    public float acceleration = 0.2f;
    public float currentMoveSpeed;
    private bool isPowerUpActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //isPowerUpActive = true;
            //ApplySlowDownEffect(collision.gameObject);
            // Khi nhân v?t ?n v?t ph?m, áp d?ng hi?u ?ng làm ch?m t?c ??
            // và sau ?ó h?y v?t ph?m (tùy theo yêu c?u c?a b?n)
            if (currentMoveSpeed > initialMoveSpeed)
            {
                currentMoveSpeed -= acceleration * Time.deltaTime;
            }
            gameObject.SetActive(false);
        }
    }

    //private void ApplySlowDownEffect(GameObject player)
    //{
    //    if (player != null && isPowerUpActive)
    //    {
    //        // L?y component x? lý di chuy?n (Movement) c?a nhân v?t
    //        PlayerMovement movementController = player.GetComponent<PlayerMovement>();

    //        // N?u nhân v?t có component x? lý di chuy?n
    //        if (movementController != null)
    //        {
    //            // Áp d?ng hi?u ?ng làm ch?m t?c ??
    //            movementController.ApplySlowDown(slowDownFactor);

    //            // T?t hi?u ?ng sau m?t kho?ng th?i gian
    //            StartCoroutine(RemoveSlowDownEffectAfterDuration(player));
    //        }
    //    }
    //}

    //private IEnumerator RemoveSlowDownEffectAfterDuration(GameObject player)
    //{
    //    yield return new WaitForSeconds(slowDownDuration);

    //    if (player != null)
    //    {
    //        PlayerMovement movementController = player.GetComponent<PlayerMovement>();
    //        if (movementController != null)
    //        {
    //            // H?i ph?c t?c ?? ban ??u
    //            movementController.ResetSpeed();
    //        }
    //    }
    //}
}
