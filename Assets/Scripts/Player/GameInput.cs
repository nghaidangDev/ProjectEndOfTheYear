using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private InputPlayerMove inputPlayerMove;

    private void Awake()
    {
        inputPlayerMove = new InputPlayerMove();
        inputPlayerMove.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalize()
    {
        Vector2 inputVector = inputPlayerMove.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
