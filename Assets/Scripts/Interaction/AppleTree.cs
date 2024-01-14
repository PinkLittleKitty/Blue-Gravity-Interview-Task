using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour, IInteractable
{
    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        Player.instance.GiveApple(Random.Range(1, 5));
        interactSuccessful = true;
    }
}
