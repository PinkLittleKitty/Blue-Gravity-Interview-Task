using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    // Animator component for controlling player animations
    private Animator animator;

    // Array of Vector2 positions representing different facing directions
    private Vector2[] positions;

    // Index of the current facing direction in the positions array
    private int currentPosition;

    private void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Create an array of facing directions
        CreatePositions();
    }

    // Method to create an array of facing directions
    private void CreatePositions()
    {
        positions = new Vector2[4];
        positions[0] = new Vector2(0, -1);      // Down
        positions[1] = new Vector2(-1, 0);      // Left
        positions[2] = new Vector2(0, 1);       // Up
        positions[3] = new Vector2(1, 0);       // Right
    }

    // Method to rotate the player character to the left
    public void RotateLeft()
    {
        // Check if there is a next position
        if (currentPosition < positions.Length - 1)
        {
            currentPosition++;
        }
        else
        {
            // Wrap around to the first position if at the last position
            currentPosition = 0;
        }

        // Update the player's facing direction
        UpdatePosition();
    }

    // Method to rotate the player character to the right
    public void RotateRight()
    {
        // Check if there is a previous position
        if (currentPosition > 0)
        {
            currentPosition--;
        }
        else
        {
            // Wrap around to the last position if at the first position
            currentPosition = positions.Length - 1;
        }

        // Update the player's facing direction
        UpdatePosition();
    }

    // Method to update the player's facing direction in the Animator
    private void UpdatePosition()
    {
        animator.SetFloat("moveX", positions[currentPosition].x);
        animator.SetFloat("moveY", positions[currentPosition].y);
    }
}
