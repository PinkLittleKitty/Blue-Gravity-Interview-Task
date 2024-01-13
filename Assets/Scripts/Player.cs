using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector3 playerMovement;
    private Rigidbody2D _rigidbody;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
        playerMovement.Normalize();
        
        UpdateAnimationAndMove();
    }

    private void UpdateAnimationAndMove()
    {
        if (playerMovement != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", playerMovement.x);
            animator.SetFloat("moveY", playerMovement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void MoveCharacter()
    {
        _rigidbody.MovePosition(transform.position + playerMovement * _speed * Time.deltaTime);
    }
}
