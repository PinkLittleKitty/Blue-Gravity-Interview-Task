using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IInteractable
{
    // Reference to the wardrobe menu GameObject
    [SerializeField] private GameObject wardrobeMenu;

    // Implementation of the IInteractable interface method
    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        // Set the player's interacting state to true
        Player.instance.interacting = true;

        // Copy the current body parts configuration to the wardrobe menu
        wardrobeMenu.GetComponentInChildren<BodyPartsSelector>().CopyCurrentBodyParts();

        // Activate the wardrobe menu
        wardrobeMenu.SetActive(true);

        // Disable player movement
        InputManager.instance.DisableMovement();

        // Set interactSuccessful to true since the interaction was successful
        interactSuccessful = true;
    }
}
