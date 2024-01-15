using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    // ID of the item associated with the button
    public int ItemID;

    // Reference to the ScriptableObject representing the body part associated with the button
    public BodyPartSO bodyPartSO;

    // Reference to the TextMeshProUGUI for displaying the item price
    public TextMeshProUGUI priceText;

    // Reference to the GameObject for displaying a "Sold Out" sprite
    public GameObject SoldOutSprite;

    // Reference to the GameObject for displaying an icon sprite
    public GameObject IconSprite;

    // Reference to the overall shop manager
    public GameObject shopManager;

    private void Start()
    {
        // Set the price text based on the item's price in the shop manager
        priceText.text = "Price: " + shopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
    }

    void Update()
    {
        // Check if the item is sold out or already bought
        if (shopManager.GetComponent<ShopManager>().shopItems[3, ItemID] == 1 || bodyPartSO.Bought == true)
        {
            // Disable interaction and change appearance for sold out or bought items
            this.gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            this.gameObject.GetComponent<Button>().interactable = false;
            priceText.text = ""; // Clear the price text for sold out or bought items
            IconSprite.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1); // Adjust the color of the icon sprite
            SoldOutSprite.SetActive(true); // Activate the "Sold Out" sprite
        }
    }
}
