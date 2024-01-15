using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    // Implementation of the IInteractable interface method
    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        // Give the player 100 money when the chest is interacted with
        Player.instance.GiveMoney(100);

        // Set interactSuccessful to true since the interaction was successful
        interactSuccessful = true;
    }
}