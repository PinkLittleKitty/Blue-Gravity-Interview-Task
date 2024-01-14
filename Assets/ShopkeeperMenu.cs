using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperMenu : MonoBehaviour
{
    public void Buy()
    {
        // TODO: Implement buying and applying to playable character
        Debug.Log("Bought!");
        InputManager.instance.EnableMovement();
        this.gameObject.SetActive(false);
    }

    public void Cancel()
    {
        // TODO: Implement Canceling and returning the playable character to its previous state
        Debug.Log("Canceled!");
        InputManager.instance.EnableMovement();
        this.gameObject.SetActive(false);
    }
}
