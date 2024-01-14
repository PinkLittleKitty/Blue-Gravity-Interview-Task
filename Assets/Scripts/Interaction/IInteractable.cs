using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public GameObject InteractionPrompt { get; }

    public void OnInteract(Interactor interactor, out bool interactSuccessful);
}
