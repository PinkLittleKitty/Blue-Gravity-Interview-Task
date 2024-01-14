using System;
using TMPro;
using UnityEngine;

public class BodyPartsSelector : MonoBehaviour
{
    [SerializeField] private CharacterBodySO characterBody;
    [SerializeField] private BodyPartSelection[] bodyPartSelections;

    private int currentBody;
    private int currentClothes;
    private int currentHair;

    private void Start()
    {
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            GetCurrentBodyPartsNamesAndAnims(i);
        }
    }

    public void CopyCurrentBodyParts()
    {
        currentBody =  GetCurrentBodyPartsIndex(0);
        currentClothes = GetCurrentBodyPartsIndex(1);
        currentHair = GetCurrentBodyPartsIndex(2);;
    }

    public void CancelBodyPartsUpdate()
    {
        characterBody.characterBodyParts[0].bodyPart = bodyPartSelections[0].bodyPartOptions[currentBody];
        characterBody.characterBodyParts[1].bodyPart = bodyPartSelections[1].bodyPartOptions[currentClothes];
        characterBody.characterBodyParts[2].bodyPart = bodyPartSelections[2].bodyPartOptions[currentHair];
    }

    private int GetCurrentBodyPartsIndex(int partIndex)
    {
        return bodyPartSelections[partIndex].bodyPartCurrentIndex;
    }


    public void NextBodyPart(int partIndex)
    {
        int initialBodyPartIndex = bodyPartSelections[partIndex].bodyPartCurrentIndex;
        int totalBodyParts = bodyPartSelections[partIndex].bodyPartOptions.Length;
        int nextBodyPartIndex = initialBodyPartIndex;

        do
        {
            nextBodyPartIndex = (nextBodyPartIndex + 1) % totalBodyParts;
        }
        while (bodyPartSelections[partIndex].bodyPartOptions[nextBodyPartIndex].Bought == false && nextBodyPartIndex != initialBodyPartIndex);

        if (nextBodyPartIndex != initialBodyPartIndex)
        {
            bodyPartSelections[partIndex].bodyPartCurrentIndex = nextBodyPartIndex;
            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBody(int partIndex)
    {
        int initialBodyPartIndex = bodyPartSelections[partIndex].bodyPartCurrentIndex;
        int totalBodyParts = bodyPartSelections[partIndex].bodyPartOptions.Length;
        int nextBodyPartIndex = initialBodyPartIndex;

        do
        {
            nextBodyPartIndex = (nextBodyPartIndex + totalBodyParts - 1) % totalBodyParts;
        }
        while (bodyPartSelections[partIndex].bodyPartOptions[nextBodyPartIndex].Bought == false && nextBodyPartIndex != initialBodyPartIndex);

        if (nextBodyPartIndex != initialBodyPartIndex)
        {
            bodyPartSelections[partIndex].bodyPartCurrentIndex = nextBodyPartIndex;
            UpdateCurrentPart(partIndex);
        }
    }


    private void GetCurrentBodyPartsNamesAndAnims(int partIndex)
    {
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartName;
        bodyPartSelections[partIndex].bodyPartCurrentIndex = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID;
    }

    private void UpdateCurrentPart(int partIndex)
    {
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex].bodyPartName;
        characterBody.characterBodyParts[partIndex].bodyPart = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex];
    }

    private void Update()
    {
        if (Player.instance.interacting == true && InputManager.instance.playerInput.Movement.Interaction.WasPressedThisFrame())
        {
            Player.instance.interacting = false;
            CancelBodyPartsUpdate();
            this.transform.parent.gameObject.SetActive(false);
            InputManager.instance.EnableMovement();
        }
    }
}

[System.Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public BodyPartSO[] bodyPartOptions;
    public TextMeshProUGUI bodyPartNameTextComponent;
    [HideInInspector] public int bodyPartCurrentIndex;
}
