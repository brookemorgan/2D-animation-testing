using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        animator.SetBool("IsWalking", Input.GetButton("Horizontal"));
	}
}