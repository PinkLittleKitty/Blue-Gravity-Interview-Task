using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI sellAppleText;
    public int[,] shopItems = new int[5, 5];

    void Start()
    {
        //This are the IDs
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;

        //This are the prices
        shopItems[2,1] = 100;
        shopItems[2,2] = 200;
        shopItems[2,3] = 250;
        shopItems[2,4] = 300;

        //This is the quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
    }

    public void UpdateAppleSellText()
    {
        sellAppleText.text = "Sell Apples (" + Player.instance.Apple * 10 + ")";
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        var ButtonRefInfo = ButtonRef.GetComponent<ButtonInfo>();

        if (Player.instance.Money >= shopItems[2, ButtonRefInfo.ItemID])
        {
            Player.instance.GiveMoney(-shopItems[2, ButtonRefInfo.ItemID]);
            ButtonRefInfo.bodyPartSO.Bought = true;
            shopItems[3, ButtonRefInfo.ItemID] += 1;
        }
    }

    private void Update()
    {
        UpdateAppleSellText();
        if (Player.instance.interacting == true && InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
        {
            this.gameObject.SetActive(false);
            InputManager.instance.EnableMovement();
        }
    }
}
