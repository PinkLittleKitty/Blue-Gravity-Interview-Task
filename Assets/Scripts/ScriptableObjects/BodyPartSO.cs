using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "Blue-Gravity-Interview-Task/Body Part")]
public class BodyPartSO : ScriptableObject
{
    public string bodyPartName;
    public int ShopID;
    public int bodyPartAnimationID;
    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();
    public bool Bought;
}
