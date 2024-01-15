using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    // Method called when an object is interacted with
    // Takes an Interactor parameter to represent the entity interacting (e.g., a player)
    // out bool interactSuccessful: a boolean parameter indicating whether the interaction was successful
    void OnInteract(Interactor interactor, out bool interactSuccessful);
}