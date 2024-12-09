using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateAnimations(Vector3 director)
    {
        if (director.magnitude > 0.1f)
        {
            anim.SetFloat("Horizontal", director.x);
            anim.SetFloat("Vertical", director.y);
        }
        else
        {
            anim.SetFloat("Horizontal", 0f);
            anim.SetFloat("Vertical", 0f);
        }
    }
}
