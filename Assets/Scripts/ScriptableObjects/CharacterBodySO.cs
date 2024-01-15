using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body", menuName = "Blue-Gravity-Interview-Task/Character Body")]
public class CharacterBodySO : ScriptableObject
{
    // Array of BodyPart structures representing individual parts of the character's body
    public BodyPart[] characterBodyParts;
}

// BodyPart class represents a specific part of the character's body configuration
[System.Serializable]
public class BodyPart
{
    // Name of the body part
    public string bodyPartName;

    // Reference to a ScriptableObject (BodyPartSO) representing the configuration for this body part
    public BodyPartSO bodyPart;
}
