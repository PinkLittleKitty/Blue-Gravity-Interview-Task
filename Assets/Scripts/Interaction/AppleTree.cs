using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour, IInteractable
{
    // Flag to track whether the tree was just interacted with
    private bool JustInteracted = false;

    // Reference to a GameObject representing the tree without apples
    public GameObject TreeNoApple;

    // Audio clip for the sound of picking up an apple
    public AudioClip applePickupClip;

    // Implementation of the IInteractable interface method
    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        // Check if the tree was not just interacted with
        if (JustInteracted == false)
        {
            // Give the player 3 apples
            Player.instance.GiveApple(3);

            // Set JustInteracted flag to true to prevent immediate consecutive interactions
            JustInteracted = true;

            // Play the sound of picking up an apple
            Player.instance.GetComponent<AudioSource>().PlayOneShot(applePickupClip);

            // Show the tree without apples for 5 seconds
            TreeNoApple.SetActive(true);
            
            // Start a coroutine to wait for 5 seconds and allow interaction again
            StartCoroutine(WaitFiveSecondsAndAllowInteraction());
        }
        
        // Set interactSuccessful to true since the interaction was successful
        interactSuccessful = true;
    }

    // Coroutine to wait for 5 seconds and then allow interaction again
    IEnumerator WaitFiveSecondsAndAllowInteraction()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Hide the tree without apples
        TreeNoApple.SetActive(false);

        // Reset the JustInteracted flag to allow interaction again
        JustInteracted = false;
    }
}
