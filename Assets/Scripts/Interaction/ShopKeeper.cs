using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    public GameObject InteractionPrompt => throw new System.NotImplementedException();

    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        throw new System.NotImplementedException();
    }
}
