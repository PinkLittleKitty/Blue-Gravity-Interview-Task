using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject _prompt;
    private Animator animator;
    public GameObject InteractionPrompt => _prompt;

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
