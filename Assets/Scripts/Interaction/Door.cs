using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    // Reference to the Animator component for door animations
    private Animator animator;

    // Called when the script is awakened
    void Awake()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
    }

    // Implementation of the IInteractable interface method
    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        // Trigger the "OpenDoor" animation parameter to open the door
        animator.SetBool("OpenDoor", true);

        // Set interactSuccessful to true since the interaction was successful
        interactSuccessful = true;
    }

    // Method to destroy the door, for example, after it's opened
    public void DestroyDoor()
    {
        // Destroy the GameObject associated with this script (the door)
        Destroy(gameObject);
    }
}
