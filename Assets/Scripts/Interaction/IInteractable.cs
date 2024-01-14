using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void OnInteract(Interactor interactor, out bool interactSuccessful);
}
