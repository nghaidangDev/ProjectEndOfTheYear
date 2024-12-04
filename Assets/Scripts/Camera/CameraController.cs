using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    private Vector3 targetPosition;
    private float speed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    public void MoveToTarget(Vector3 position, float transitionSpeed)
    {
        targetPosition = new Vector3(position.x, position.y, Camera.main.transform.position.z);
        speed = transitionSpeed;
        StopAllCoroutines();
        StartCoroutine(SmoothTransition());
    }

    private IEnumerator SmoothTransition()
    {
        while ((Camera.main.transform.position - targetPosition).sqrMagnitude > 0.01f)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, Time.deltaTime * speed);
            yield return null;
        }
    }
}
