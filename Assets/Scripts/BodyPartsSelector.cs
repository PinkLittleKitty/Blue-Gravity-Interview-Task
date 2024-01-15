using TMPro;
using UnityEngine;

public class BodyPartsSelector : MonoBehaviour
{
    // Serialized fields are exposed in the Unity Editor
    [SerializeField] private CharacterBodySO characterBody;
    [SerializeField] private BodyPartSelection[] bodyPartSelections;

    // Keep track of the currently selected body, clothes, and hair indices
    private int currentBody;
    private int currentClothes;
    private int currentHair;

    private void Start()
    {
        // Iterate through body part selections to set initial values
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            GetCurrentBodyPartsNamesAndAnims(i);
        }
    }

    // Copy the current body parts indices for possible cancellation
    public void CopyCurrentBodyParts()
    {
        currentBody = GetCurrentBodyPartsIndex(0);
        currentClothes = GetCurrentBodyPartsIndex(1);
        currentHair = GetCurrentBodyPartsIndex(2);
    }

    // Revert changes made to body parts during the selection process
    public void CancelBodyPartsUpdate()
    {
        bodyPartSelections[0].bodyPartCurrentIndex = currentBody;
        UpdateCurrentPart(0);
        bodyPartSelections[1].bodyPartCurrentIndex = currentClothes;
        UpdateCurrentPart(1);
        bodyPartSelections[2].bodyPartCurrentIndex = currentHair;
        UpdateCurrentPart(2);
    }

    // Get the current index of a specified body part type
    private int GetCurrentBodyPartsIndex(int partIndex)
    {
        return bodyPartSelections[partIndex].bodyPartCurrentIndex;
    }

    // Switch to the next available body part for a given type
    public void NextBodyPart(int partIndex)
    {
        int initialBodyPartIndex = bodyPartSelections[partIndex].bodyPartCurrentIndex;
        int totalBodyParts = bodyPartSelections[partIndex].bodyPartOptions.Length;
        int nextBodyPartIndex = initialBodyPartIndex;

        // Find the next available body part
        do
        {
            nextBodyPartIndex = (nextBodyPartIndex + 1) % totalBodyParts;
        } while (bodyPartSelections[partIndex].bodyPartOptions[nextBodyPartIndex].Bought == false && nextBodyPartIndex != initialBodyPartIndex);

        // If a new part is found, update and apply changes
        if (nextBodyPartIndex != initialBodyPartIndex)
        {
            bodyPartSelections[partIndex].bodyPartCurrentIndex = nextBodyPartIndex;
            UpdateCurrentPart(partIndex);
        }
    }

    // Switch to the previous available body part for a given type
    public void PreviousBody(int partIndex)
    {
        int initialBodyPartIndex = bodyPartSelections[partIndex].bodyPartCurrentIndex;
        int totalBodyParts = bodyPartSelections[partIndex].bodyPartOptions.Length;
        int nextBodyPartIndex = initialBodyPartIndex;

        // Find the previous available body part
        do
        {
            nextBodyPartIndex = (nextBodyPartIndex + totalBodyParts - 1) % totalBodyParts;
        } while (bodyPartSelections[partIndex].bodyPartOptions[nextBodyPartIndex].Bought == false && nextBodyPartIndex != initialBodyPartIndex);

        // If a new part is found, update and apply changes
        if (nextBodyPartIndex != initialBodyPartIndex)
        {
            bodyPartSelections[partIndex].bodyPartCurrentIndex = nextBodyPartIndex;
            UpdateCurrentPart(partIndex);
        }
    }

    // Set initial values for the body parts names and animations
    private void GetCurrentBodyPartsNamesAndAnims(int partIndex)
    {
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartName;
        bodyPartSelections[partIndex].bodyPartCurrentIndex = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID;
    }

    // Update the UI and apply changes for the currently selected body part
    private void UpdateCurrentPart(int partIndex)
    {
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex].bodyPartName;
        characterBody.characterBodyParts[partIndex].bodyPart = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex];
    }
}

// Serializable class to hold information about a specific body part type
[System.Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public BodyPartSO[] bodyPartOptions;
    public TextMeshProUGUI bodyPartNameTextComponent;
    [HideInInspector] public int bodyPartCurrentIndex;
}
