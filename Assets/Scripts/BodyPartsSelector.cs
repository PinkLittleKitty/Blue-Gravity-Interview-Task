using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartsSelector : MonoBehaviour
{
    [SerializeField] private CharacterBodySO characterBody;
    [SerializeField] private BodyPartSelection[] bodyPartSelections;

    private void Start()
    {
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            GetCurrentBodyParts(i);
        }
    }

    public void NextBodyPart(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex < bodyPartSelections[partIndex].bodyPartOptions.Length - 1)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex++;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = 0;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBody(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex > 0)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex--;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = bodyPartSelections[partIndex].bodyPartOptions.Length - 1;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartSelections.Length || partIndex < 0)
        {
            Debug.LogError("Invalid part index (Does not mach a body part)");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void GetCurrentBodyParts(int partIndex)
    {
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartName;
        bodyPartSelections[partIndex].bodyPartCurrentIndex = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID;
    }

    private void UpdateCurrentPart(int partIndex)
    {
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex].bodyPartName;
        characterBody.characterBodyParts[partIndex].bodyPart = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex];
    }
}

[System.Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public BodyPartSO[] bodyPartOptions;
    public Text bodyPartNameTextComponent;
    [HideInInspector] public int bodyPartCurrentIndex;
}
