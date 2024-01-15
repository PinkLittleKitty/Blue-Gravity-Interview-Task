using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance { get; private set; }

    public PlayerControls playerInput;

    [SerializeField] private Vector3 playerMovement = Vector3.zero;

    [SerializeField] private bool IsInteracting = false;

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
        playerInput = new PlayerControls();

        EnableMovement();
    }

    public void EnableMovement()
    {
        playerInput.Movement.Movement.Enable();
    }

    public void DisableMovement()
    {
        playerInput.Movement.Movement.Disable();
    }

    private void FixedUpdate()
    {
        playerMovement = playerInput.Movement.Movement.ReadValue<Vector2>();

        Player.instance.MoveCharacter(playerMovement);
    }
}
