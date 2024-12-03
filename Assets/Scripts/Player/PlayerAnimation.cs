using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 moveDir = playerMovement.moveDir;
        Vector3 lastMoveDir = playerMovement.GetLastMoveDir();

        if (moveDir != Vector3.zero)
        {
            // Player đang di chuyển
            anim.SetFloat("VectorX", moveDir.x);
            anim.SetFloat("VectorY", moveDir.y);
            anim.SetBool("IsMoving", true);
        }
        else
        {
            // Player đứng im
            anim.SetFloat("VectorX", lastMoveDir.x);
            anim.SetFloat("VectorY", lastMoveDir.y);
            anim.SetBool("IsMoving", false);
        }
    }
}
