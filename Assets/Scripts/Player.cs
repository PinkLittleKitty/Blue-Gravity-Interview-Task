using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Singleton instance of the Player
    public static Player instance { get; private set; }

    [Header("Movement")]
    // Movement speed of the player
    [SerializeField] private float _speed = 5f;

    // Player's money and apple count
    [SerializeField] private int money;
    [SerializeField] private int apple;

    // Property to access money
    public int Money => money;

    // Text components to display money and apple counts
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI appleText;

    // Rigidbody2D component for controlling player movement
    private Rigidbody2D _rigidbody => GetComponent<Rigidbody2D>();

    // Animator component for controlling player animations
    private Animator animator => GetComponent<Animator>();

    // Flag indicating whether the player is currently interacting
    public bool interacting;

    // AudioClip for the sound effect when selling apples
    public AudioClip KaChingClip;

    private void Awake()
    {
        instance = this;
    }

    // Update the player's animation based on movement input
    private void UpdateAnimation(Vector3 playerMovement)
    {
        if (playerMovement == Vector3.zero)
        {
            animator.SetBool("moving", false);
            return;
        }

        animator.SetFloat("moveX", playerMovement.x);
        animator.SetFloat("moveY", playerMovement.y);
        animator.SetBool("moving", true);
    }

    // Give the player money
    public void GiveMoney(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }

    // Give the player apples
    public void GiveApple(int value)
    {
        apple += value;
        appleText.text = apple.ToString();
    }

    // Sell apples and gain money
    public void SellApples()
    {
        if (apple <= 0) return;

        // Play the KaChing sound effect
        GetComponent<AudioSource>().PlayOneShot(KaChingClip);

        // Give the player money based on the number of apples and reset the apple count
        GiveMoney(apple * 20);
        apple = 0;
        appleText.text = apple.ToString();
    }

    // Move the player character based on input
    public void MoveCharacter(Vector3 playerMovement)
    {
        _rigidbody.MovePosition(transform.position + playerMovement * _speed * Time.deltaTime);
        UpdateAnimation(playerMovement);
    }
}
