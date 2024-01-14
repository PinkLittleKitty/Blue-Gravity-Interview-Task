using System.Collections.Generic;
using UnityEngine;

public class BodyPartsManager : MonoBehaviour
{
    [SerializeField] private CharacterBodySO characterBody;

    [Header("String arrays")]
    [SerializeField] private string[] bodyPartTypes;
    [SerializeField] private string[] characterStates;
    [SerializeField] private string[] characterDirections;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController; 
    private AnimationClipOverrides defaultAnimationClips;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);
        
        UpdateBodyParts();
    }

    public void UpdateBodyParts()
    {
        for (int partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            string partType = bodyPartTypes[partIndex];

            string partID = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];
                    // The naming convention is: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_Idle_Down)
                    animationClip = Resources.Load<AnimationClip>("Animations/" + "Player/" + partType + "/" + partType + "_" + partID + "_" + state + "_" + direction);
                    defaultAnimationClips[partType + "_" + 0 + "_" + state + "_" + direction] = animationClip;
                }
            }
        }

        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}
