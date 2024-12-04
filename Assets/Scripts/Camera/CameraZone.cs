using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public Transform cameraTarget;
    public float transitionSpeed = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraController.Instance.MoveToTarget(cameraTarget.position, transitionSpeed);
        }
    }
}
