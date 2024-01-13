using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body", menuName = "Blue-Gravity-Interview-Task/Character Body")]
public class CharacterBodySO : ScriptableObject
{
    public BodyPart[] characterBodyParts;
}

[System.Serializable]
public class BodyPart
{
    public string bodyPartName;
    public BodyPartSO bodyPart;
}
