using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Interactor class represents an object that can interact with other objects
public class Interactor : MonoBehaviour
{
    // Reference to the interaction point, where interactions are checked
    [SerializeField] private Transform _interactionPoint;

    // Radius of the interaction point
    [SerializeField] private float _interactionPointRadius = 0.7f;

    // Layer mask to filter interactable objects
    [SerializeField] private LayerMask _interactableMask;

    // Reference to the UI for interaction prompts
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    // Array to store colliders found during interaction checks
    private readonly Collider2D[] _colliders = new Collider2D[3];

    // Number of colliders found during interaction checks
    [SerializeField] private int _numFound;

    // Reference to the currently interactable object
    public IInteractable _interactable;

    // Input action for the interaction key
    public InputAction InteractionKey;

    private void Start()
    {
        // Get the InteractionKey input action from the player input
        InteractionKey = InputManager.instance.playerInput.Movement.Interaction;
        InteractionKey.Enable();
    }

    private void OnDisable()
    {
        // Disable the InteractionKey input action
        InteractionKey.Disable();
    }

    private void Update()
    {
        // Perform overlap circle check to find interactable objects
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        // Check if any interactable objects are found
        if (_numFound > 0)
        {
            // Get the IInteractable component from the first collider
            _interactable = _colliders[0].GetComponent<IInteractable>();
            if (_interactable == null) return;

            // Display the interaction prompt UI if not already displayed
            if (!_interactionPromptUI.IsDisplayed)
            {
                _interactionPromptUI.SetUp();
            }

            // Check if the interaction key is pressed
            if (InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
            {
                // Call the OnInteract method on the interactable object
                _interactable.OnInteract(this, out bool interactSuccessful);
            }
        }
        else
        {
            // Reset the interactable reference if no interactable objects are found
            _interactable = (_interactable != null) ? null : _interactable;

            // Close the interaction prompt UI if displayed
            if (_interactionPromptUI.IsDisplayed)
            {
                _interactionPromptUI.Close();
            }
        }
    }

    // Visualize the interaction point radius in the Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
