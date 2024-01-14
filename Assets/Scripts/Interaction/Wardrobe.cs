using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wardrobeMenu;
    public GameObject InteractionPrompt => throw new System.NotImplementedException();

    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        wardrobeMenu.SetActive(true);
        InputManager.instance.DisableMovement();
        interactSuccessful = true;
    }
}
