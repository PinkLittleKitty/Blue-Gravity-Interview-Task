using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    [Header("Movement")]
    [SerializeField] private float _speed = 5f;

    [SerializeField] private int money;
    [SerializeField] private int apple;

    public int Money => money;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI appleText;

    private Rigidbody2D _rigidbody => GetComponent<Rigidbody2D>();

    private Animator animator => GetComponent<Animator>();

    public bool interacting;

    public AudioClip KaChingClip;

    private void Awake()
    {
        instance = this;
    }

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

    public void GiveMoney(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }

    public void GiveApple(int value)
    {
        apple += value;
        appleText.text = apple.ToString();
    }

    public void SellApples()
    {
        if (apple <= 0) return;

        GetComponent<AudioSource>().PlayOneShot(KaChingClip);

        GiveMoney(apple * 20);
        apple = 0;
        appleText.text = apple.ToString();
    }

    public void MoveCharacter(Vector3 playerMovement)
    {
        _rigidbody.MovePosition(transform.position + playerMovement * _speed * Time.deltaTime);
        UpdateAnimation(playerMovement);
    }
}
