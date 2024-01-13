using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "Blue-Gravity-Interview-Task/Body Part")]
public class BodyPartSO : ScriptableObject
{
    public string bodyPartName;
    public int bodyPartAnimationID;
    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();
}
