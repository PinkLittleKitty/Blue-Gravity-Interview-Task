using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wardrobeMenu;

    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        Player.instance.interacting = true;

        wardrobeMenu.GetComponentInChildren<BodyPartsSelector>().CopyCurrentBodyParts();

        wardrobeMenu.SetActive(true);

        InputManager.instance.DisableMovement();

        interactSuccessful = true;
    }
}
