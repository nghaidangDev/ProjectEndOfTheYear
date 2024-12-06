using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float limitBullet = 5f;

    private void Start()
    {
        StartCoroutine(WaitRespawnBullet());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    IEnumerator WaitRespawnBullet()
    {
        yield return new WaitForSeconds(limitBullet);

        gameObject.SetActive(false);
    }
}
