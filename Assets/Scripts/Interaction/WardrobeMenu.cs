using UnityEngine;

public class WardrobeMenu : MonoBehaviour
{
    // Reference to the BodyPartsManager for managing character body parts
    public BodyPartsManager bodyPartsManager;

    // Reference to the BodyPartsManagerPreview for managing preview body parts
    public BodyPartsManager bodyPartsManagerPreview;

    // Reference to the BodyPartsSelector for selecting body parts
    public BodyPartsSelector bodyPartsSelector;

    // Method to accept changes made in the wardrobe menu
    public void Accept()
    {
        // Update the character's body parts based on the changes made
        bodyPartsManager.UpdateBodyParts();

        // Enable player movement
        InputManager.instance.EnableMovement();

        // Deactivate the wardrobe menu
        gameObject.SetActive(false);
    }

    // Method to cancel changes made in the wardrobe menu
    public void Cancel()
    {
        // Cancel the body parts update in the selector
        bodyPartsSelector.CancelBodyPartsUpdate();

        // Update the character's body parts based on the original configuration
        bodyPartsManager.UpdateBodyParts();

        // Update the preview body parts based on the original configuration
        bodyPartsManagerPreview.UpdateBodyParts();

        // Enable player movement
        InputManager.instance.EnableMovement();

        // Deactivate the wardrobe menu
        gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check for interaction and cancel changes if needed
        if (Player.instance.interacting == true && InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
        {
            // Reset the interacting state of the player
            Player.instance.interacting = false;

            // Call the Cancel method to revert changes
            Cancel();
        }
    }
}