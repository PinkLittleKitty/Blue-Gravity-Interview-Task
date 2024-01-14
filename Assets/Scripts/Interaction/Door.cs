using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        interactSuccessful = true;
        Destroy(gameObject);
    }
}