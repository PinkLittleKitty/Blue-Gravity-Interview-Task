using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if (InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
            {
                other.gameObject.GetComponent<IInteractable>().OnInteract(this, out bool interactSuccessful);
            }
        }   
    }
}
