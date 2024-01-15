using UnityEngine;

public class WardrobeMenu : MonoBehaviour
{
    public BodyPartsManager bodyPartsManager;

    public BodyPartsManager bodyPartsManagerPreview;

    public BodyPartsSelector bodyPartsSelector;

    public void Accept()
    {
        bodyPartsManager.UpdateBodyParts();

        InputManager.instance.EnableMovement();

        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        bodyPartsSelector.CancelBodyPartsUpdate();

        bodyPartsManager.UpdateBodyParts();

        bodyPartsManagerPreview.UpdateBodyParts();

        InputManager.instance.EnableMovement();

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Player.instance.interacting == true && InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
        {
            Player.instance.interacting = false;

            Cancel();
        }
    }
}