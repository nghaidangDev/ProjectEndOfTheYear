using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;

    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void HandleInteractions()
    {

    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalize();

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0);

        float moveDistance = moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        transform.position += moveDir * moveDistance;
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
