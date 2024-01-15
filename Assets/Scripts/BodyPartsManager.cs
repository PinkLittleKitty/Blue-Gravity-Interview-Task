using System.Collections.Generic;
using UnityEngine;

public class BodyPartsManager : MonoBehaviour
{
    public static BodyPartsManager instance { get; private set; }

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

    void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Create an AnimatorOverrideController to modify animations at runtime
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        // Create a copy of the default animation clips
        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        UpdateBodyParts();
    }

    public void UpdateBodyParts()
    {
        for (int partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            string partType = bodyPartTypes[partIndex];

            // Get the body part ID from the character's configuration
            string partID = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];

                    // Load the animation clip from Resources folder, using the part type, index, state, and direction
                    // The naming convention is: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_Idle_Down)
                    animationClip = Resources.Load<AnimationClip>("Animations/" + "Player/" + partType + "/" + partType + "_" + partID + "_" + state + "_" + direction);

                    defaultAnimationClips[partType + "_" + 0 + "_" + state + "_" + direction] = animationClip;
                }
            }
        }

        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

    // Class representing overrides for animation clips (Taken from unity's documentation https://docs.unity3d.com/ScriptReference/AnimatorOverrideController.html)
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
