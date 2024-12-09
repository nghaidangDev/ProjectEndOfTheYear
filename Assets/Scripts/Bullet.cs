using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float limitBullet = 5f;

    private void Start()
    {
        StartCoroutine(WaitRespawnBullet());
    }
    IEnumerator WaitRespawnBullet()
    {
        yield return new WaitForSeconds(limitBullet);

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Find script Health of Enemy
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamge(10f);
            }

            gameObject.SetActive(false);
        }
    }
}
