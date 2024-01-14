using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperMenu : MonoBehaviour
{

    //TODO: The shopkeeper should sell you "Items" (Clothes, based on the ID, to know if you have them or you don't.)
    //TODO: So, here should be an inventory of kinds to be able to select the items you want to buy, and then do the checkout.

    
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
