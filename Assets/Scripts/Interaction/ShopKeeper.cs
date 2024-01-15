using UnityEngine;

public class ShopKeeper : MonoBehaviour, IInteractable
{
    // Reference to the shopkeeper menu GameObject
    [SerializeField] private GameObject shopKeeperMenu;

    // Implementation of the IInteractable interface method
    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        // Activate the shopkeeper menu
        shopKeeperMenu.SetActive(true);

        // Disable player movement
        InputManager.instance.DisableMovement();

        // Set the player's interacting state to true
        Player.instance.interacting = true;

        // Set interactSuccessful to true since the interaction was successful
        interactSuccessful = true;
    }
}
