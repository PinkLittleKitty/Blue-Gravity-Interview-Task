using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "Blue-Gravity-Interview-Task/Body Part")]
public class BodyPartSO : ScriptableObject
{
    // Name of the body part
    public string bodyPartName;

    // Unique ID for the body part in the shop
    public int ShopID;

    // ID for the animation associated with this body part
    public int bodyPartAnimationID;

    // List of all animation clips associated with this body part
    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();

    // Flag indicating whether the body part has been bought
    public bool Bought;
}
