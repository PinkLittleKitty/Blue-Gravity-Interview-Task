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
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        var ButtonRefInfo = ButtonRef.GetComponent<ButtonInfo>();

        if (Player.instance.Money >= shopItems[2, ButtonRefInfo.ItemID])
        {
            Player.instance.GiveMoney(-shopItems[2, ButtonRefInfo.ItemID]);
            ButtonRefInfo.bodyPartSO.Bought = true;
        }
    }

    private void Update()
    {
        if (Player.instance.interacting == true && InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
        {
            this.gameObject.SetActive(false);
            InputManager.instance.EnableMovement();
        }
    }
}
