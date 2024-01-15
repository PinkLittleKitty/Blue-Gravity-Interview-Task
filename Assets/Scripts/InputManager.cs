using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Singleton instance of the InputManager
    public static InputManager instance { get; private set; }

    // PlayerControls reference for managing input actions
    public PlayerControls playerInput;

    // Vector representing the player's movement input
    [SerializeField] private Vector3 playerMovement = Vector3.zero;

    // Flag indicating whether the player is currently interacting
    [SerializeField] private bool IsInteracting = false;

    // Getter method to check if the player is interacting
    public bool GetIsInteracting()
    {
        return IsInteracting;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Initialize the PlayerControls
        playerInput = new PlayerControls();

        // Enable player movement by default
        EnableMovement();
    }

    // Method to enable player movement
    public void EnableMovement()
    {
        playerInput.Movement.Movement.Enable();
    }

    // Method to disable player movement
    public void DisableMovement()
    {
        playerInput.Movement.Movement.Disable();
    }

    private void FixedUpdate()
    {
        // Read the player's movement input
        playerMovement = playerInput.Movement.Movement.ReadValue<Vector2>();

        // Send the movement input to the Player class to move the character
        Player.instance.MoveCharacter(playerMovement);
    }
}
