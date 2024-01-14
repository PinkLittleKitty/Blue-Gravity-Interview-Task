using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public BodyPartSO bodyPartSO;
    public TextMeshProUGUI priceText;
    public GameObject SoldOutSprite;
    public GameObject IconSprite;
    public GameObject shopManager;

    void Update()
    {
        priceText.text = "Price: " + shopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        if (shopManager.GetComponent<ShopManager>().shopItems[3, ItemID] == 1 || bodyPartSO.Bought == true)
        {
            this.gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            this.gameObject.GetComponent<Button>().interactable = false;
            priceText.text = "";
            IconSprite.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            SoldOutSprite.SetActive(true);
        }
    }
}
