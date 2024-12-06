using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] private float maxDistance;
    [SerializeField] private float forceShoot;

    [SerializeField] private LayerMask EnemyLayer;

    //[SerializeField] private GameObject prefabBullet;

    [SerializeField] private Transform posBullet;

    private void Update()
    {
        Vector2 moveDir = playerMovement.GetLastMoveDir();

        //Type data of Raycast is raycasthit2d
        RaycastHit2D isEnemy = Physics2D.Raycast(transform.position, moveDir, maxDistance, EnemyLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check raycast equal collider != null
            if (isEnemy.collider != null)
            {
                GameObject bullet = ObjectPool.instance.GetPoolObject();

                if (bullet != null)
                {
                    bullet.transform.position = posBullet.position;
                    bullet.SetActive(true);
                }

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.AddForce(moveDir *  forceShoot);
                }
            }
        }

        Debug.DrawRay(transform.position, moveDir * maxDistance, Color.red);
    }
}
