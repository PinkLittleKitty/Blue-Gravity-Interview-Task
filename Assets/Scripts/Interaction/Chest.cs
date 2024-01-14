using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public GameObject InteractionPrompt => throw new System.NotImplementedException();

    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        Player.instance.GiveMoney(100);
        interactSuccessful = true;
    }
}
