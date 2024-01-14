using UnityEngine;

public class WardrobeMenu : MonoBehaviour
{
    public BodyPartsManager bodyPartsManager;
    public BodyPartsSelector bodyPartsSelector;
    public void accept()
    {
        bodyPartsManager.UpdateBodyParts();
        InputManager.instance.EnableMovement();
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        bodyPartsSelector.CancelBodyPartsUpdate();
        InputManager.instance.EnableMovement();
        gameObject.SetActive(false);
    }
}
