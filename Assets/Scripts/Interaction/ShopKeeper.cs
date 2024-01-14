using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject shopKeeperMenu;
    public GameObject InteractionPrompt => throw new System.NotImplementedException();

    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        shopKeeperMenu.SetActive(true);
        InputManager.instance.DisableMovement();
        interactSuccessful = true;
    }
}
