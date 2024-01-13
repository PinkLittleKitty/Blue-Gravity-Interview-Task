using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
