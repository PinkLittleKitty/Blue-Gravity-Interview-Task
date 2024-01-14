using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 5f;

    [SerializeField] private int money;

    private Rigidbody2D _rigidbody => GetComponent<Rigidbody2D>();

    private Animator animator => GetComponent<Animator>();

    public static Player instance { get; private set; }


    private void Awake()
    {
        instance = this;
    }

    private void UpdateAnimation(Vector3 playerMovement)
    {
        if (playerMovement == Vector3.zero)
        {
            animator.SetBool("moving", false);
            return;
        }

        animator.SetFloat("moveX", playerMovement.x);
        animator.SetFloat("moveY", playerMovement.y);
        animator.SetBool("moving", true);
    }

    public void GiveMoney(int value)
    {
        money += value;
    }


    public void MoveCharacter(Vector3 playerMovement)
    {
        _rigidbody.MovePosition(transform.position + playerMovement * _speed * Time.deltaTime);
        UpdateAnimation(playerMovement);
    }
}
