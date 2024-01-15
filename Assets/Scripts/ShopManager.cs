using UnityEngine;
using UnityEngine.EventSystems;


public class ShopManager : MonoBehaviour
{
    // 2D array to store shop item information (IDs, prices, quantities)
    public int[,] shopItems = new int[5, 5];


    void Start()
    {
        // Initialize shop item IDs
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        // Initialize shop item prices
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 200;
        shopItems[2, 3] = 250;
        shopItems[2, 4] = 300;

        // Initialize shop item quantities
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
    }

    // Method to handle the buying of items in the shop
    public void Buy()
    {
        // Get the reference to the currently selected button using EventSystem
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        var ButtonRefInfo = ButtonRef.GetComponent<ButtonInfo>();

        // Check if the player has enough money to buy the selected item
        if (Player.instance.Money >= shopItems[2, ButtonRefInfo.ItemID])
        {
            // Deduct money from the player and mark the item as bought
            Player.instance.GiveMoney(-shopItems[2, ButtonRefInfo.ItemID]);
            ButtonRefInfo.bodyPartSO.Bought = true;

            // Increase the quantity of the bought item in the shop
            shopItems[3, ButtonRefInfo.ItemID] += 1;
        }
    }

    private void Update()
    {
        // Check for interaction and close the shop if needed
        if (Player.instance.interacting == true && InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
        {
            this.gameObject.SetActive(false);
            InputManager.instance.EnableMovement();
        }
    }
}
