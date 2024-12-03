using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameInput gameInput;

    public Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalize();

        moveDir = new Vector3(inputVector.x, inputVector.y, 0);

        if (moveDir != Vector3.zero)
        {
            lastMoveDir = moveDir;  
        }

        float moveDistance = moveSpeed * Time.deltaTime;

        transform.position += moveDir * moveDistance;
    }

    public Vector3 GetLastMoveDir()
    {
        return lastMoveDir;
    }
}
